using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OwlsEat
{
    public partial class RestaurantManageMenu : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        ArrayList UpdateInformationError = new ArrayList();



        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Session["userEmail"] as string))
            {
                Response.Redirect("NoAccess.aspx");
            }

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetAllByRestaurantID";

            objCommand.Parameters.AddWithValue("@RestaurantId", Session["userid"].ToString());
            DataSet RestaruantLogo = objDB.GetDataSetUsingCmdObj(objCommand);

            string Logo = (string)objDB.GetField("ImgURL", 0);
            imgAvatar.Src = Logo;



            string userId = Session["userID"].ToString();

          

            if (!IsPostBack)
            {
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPGetItemsbyRestaurantId";

                objCommand.Parameters.AddWithValue("@RestaurantId", Session["userid"].ToString());
                DataSet Items = objDB.GetDataSetUsingCmdObj(objCommand);

                gvItems.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                gvItems.DataBind();

                ddlItemID.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                ddlItemID.DataTextField = "Title";
                ddlItemID.DataValueField = "ItemID";
                ddlItemID.DataBind();

                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPGetMenusByRestarauntID";

                objCommand.Parameters.AddWithValue("@RestaurantId", Session["userid"].ToString());
                DataSet Menus = objDB.GetDataSetUsingCmdObj(objCommand);

                ddlEditMenus.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
                ddlEditMenus.DataTextField = "MenuName";
                ddlEditMenus.DataValueField = "MenuID";
                ddlEditMenus.DataBind();

                AddItemsToMenu.Visible = true;


            }
        }

        void ValidateItemInformation()
        {
            if (txtItemTitle.Text == "")
            {
                UpdateInformationError.Add("Enter Item");

            }
            if (txtItemImgUrl.Text == "")
            {
                UpdateInformationError.Add("Please Upload Image");
            }
            if (txtDescription.Text == "")
            {
                UpdateInformationError.Add("Enter Description");
            }
            if (txtItemPrice.Text == "")
            {
                UpdateInformationError.Add("Enter Price");
            }

        }

        void ValidateEditItemInformation()
        {
            if (txtItemTitle1.Text == "")
            {
                UpdateInformationError.Add("Enter Item");

            }
            if (txtItemImgUrl1.Text == "")
            {
                UpdateInformationError.Add("Please Upload Image");
            }
            if (txtItemDescription.Text == "")
            {
                UpdateInformationError.Add("Enter Description");
            }
            if (txtItemPrice1.Text == "")
            {
                UpdateInformationError.Add("Enter Price");
            }

        }

        void ValidateMenu()
        {

            if (txtMenuTitle.Text == "")
            {
                UpdateInformationError.Add("Enter Title");

            }
            if (txtMenuDescription.Text == "")
            {
                UpdateInformationError.Add("Enter Description");

            }
            if (txtMenuImage.Text == "")
            {
                UpdateInformationError.Add("Enter Image");

            }

        }

        void ValidateEditMenu()
        {

            if (txtMenuName1.Text == "")
            {
                UpdateInformationError.Add("Enter Title");

            }
            if (txtMenuDescription1.Text == "")
            {
                UpdateInformationError.Add("Enter Description");

            }
            if (txtMenuImgUrl.Text == "")
            {
                UpdateInformationError.Add("Enter Image");

            }

        }

        protected void lnkBtnChangePassword_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;

        }

        protected void btnCreateItem_Click(object sender, EventArgs e)
        {
            ValidateItemInformation();

            if (UpdateInformationError.Count == 0)
            {

                string ItemTitle = txtItemTitle.Text;
                string ItemImgUrl = txtItemImgUrl.Text;
                string ItemDescription = txtDescription.Text;
                float ItemPrice = float.Parse(txtItemPrice.Text);

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPInsertItem";

                objCommand.Parameters.AddWithValue("@Title", ItemTitle);
                objCommand.Parameters.AddWithValue("@Description", ItemDescription);
                objCommand.Parameters.AddWithValue("@Price", ItemPrice);
                objCommand.Parameters.AddWithValue("@Image", ItemImgUrl);
                objCommand.Parameters.AddWithValue("@RestaurantID", Session["userID"].ToString());

                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                if (ResponseReceived == 1)
                {

                    lblConfirm.Text = "Thank you for creating an Item!";
                    lblConfirm.Visible = true;
                }

            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    lblConfirm.Text = "Failed";
                    lblConfirm.Visible = true;
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
        }

        protected void lnkBtnCreateItems_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            CreateMenu.Visible = false;
            ViewAndEditItems.Visible = false;
            ViewAndEditMenu.Visible = false;
            CreateItems.Visible = true;

        }

        protected void lnkBtnCreateMenu_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            CreateItems.Visible = false;
            ViewAndEditItems.Visible = false;
            ViewAndEditMenu.Visible = false;
            CreateMenu.Visible = true;

            MenuDetails.Visible = true;
            AddItemsToMenu.Visible = false;
        }

        protected void btnCreateMenu_Click(object sender, EventArgs e)
        {
            Utilities.Menu menu = new Utilities.Menu();
           

            ValidateMenu();
            if (UpdateInformationError.Count == 0)
            {
                string MenuName = txtMenuTitle.Text;
                menu.MenuName = MenuName;
                Boolean flag = menu.CheckIfMenuExists(MenuName);
                if (flag == true)
                {
                    Response.Write("Menu already exists");
                }
                else
                {

                    MenuName = txtMenuTitle.Text;
                    string MenuImgUrl = txtMenuImage.Text;
                    string MenuDescription = txtMenuDescription.Text;


                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TPInsertMenu";

                    objCommand.Parameters.AddWithValue("@MenuName", MenuName);
                    objCommand.Parameters.AddWithValue("@MenuDesc", MenuDescription);
                    objCommand.Parameters.AddWithValue("@ImgUrl", MenuImgUrl);
                    objCommand.Parameters.AddWithValue("@RestaurantID", Session["userid"].ToString());



                    var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                    if (ResponseReceived == 1)
                    {
                        objCommand.Parameters.Clear();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "TPGetMenusByMenuName";

                        objCommand.Parameters.AddWithValue("@MenuName", MenuName);
                        DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

                        int MenuID = (int)objDB.GetField("MenuID", 0);

                        lblConfirm1.Text = "Thank you for creating an Menu!";
                        lblConfirm1.Visible = true;

                        MenuDetails.Visible = false;
                        txtMenuTitle.Text = MenuName;
                        txtMenuID.Text = MenuID.ToString();
                        AddItemsToMenu.Visible = true;
                    }


                    else
                    {
                        lblConfirm1.Text = "Menu already exists";
                        lblConfirm1.Visible = true;
                        for (int i = 0; i < UpdateInformationError.Count; i++)
                        {
                            
                            Response.Write(UpdateInformationError[i] + "<br/>");
                        }
                    }
                }
            }
        }

        protected void lnkBtnViewItems_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            CreateItems.Visible = false;
            CreateMenu.Visible = false;
            ViewAndEditItems.Visible = true;
            ViewAndEditMenu.Visible = false;
            ddlItemID.Visible = true;
        }

        protected void lnkBtnViewMenus_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            CreateItems.Visible = false;
            CreateMenu.Visible = false;
            ViewAndEditItems.Visible = false;
            ViewAndEditMenu.Visible = true;
            divAdd.Visible = false;
            divRemove.Visible = false;
        }

        protected void btnEditItem_Click(object sender, EventArgs e)
        {
            ValidateEditItemInformation();

            if (UpdateInformationError.Count == 0)
            {

                string ItemTitle = txtItemTitle1.Text;
                string ItemImgUrl = txtItemImgUrl1.Text;
                string ItemDescription = txtItemDescription.Text;
                float ItemPrice = float.Parse(txtItemPrice1.Text);
                int ItemID = int.Parse(txtItemID.Text);

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPUpdateItemInfo";


                objCommand.Parameters.AddWithValue("@ItemID", ItemID);
                objCommand.Parameters.AddWithValue("@Title", ItemTitle);
                objCommand.Parameters.AddWithValue("@Image", ItemImgUrl);
                objCommand.Parameters.AddWithValue("@Description", ItemDescription);
                objCommand.Parameters.AddWithValue("@Price", ItemPrice);

                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                if (ResponseReceived == 1)
                {
                    ViewAndEditItems.Visible = false;
                    lblConfirm.Text = "Thank you for updating your items!";
                    lblConfirm.Visible = true;
                }

            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    lblConfirm.Text = "Failed";
                    lblConfirm.Visible = true;
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
        }

        protected void ddlItemID_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditItem.Visible = true;

            DBConnect objdb = new DBConnect();

            string selectedItem = ddlItemID.SelectedValue;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetItemsByItemID";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@ItemID", selectedItem);

            DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

            int ItemID = (int)objDB.GetField("ItemID", 0);
            txtItemID.Text = ItemID.ToString();
            txtItemTitle1.Text = (string)objDB.GetField("Title", 0);
            txtItemImgUrl1.Text = (string)objDB.GetField("Image", 0);
            txtItemDescription.Text = (string)objDB.GetField("Description", 0);
            double dbprice = (double)objDB.GetField("Price", 0);
            txtItemPrice1.Text = dbprice.ToString();




        }

        protected void btnAddItemstoMenu_Click(object sender, EventArgs e)
        {
            ArrayList arrProducts = new ArrayList();    // used to store the ProductNumber for each selected product
            int count = 0;                              // used to count the number of selected products
            // Iterate through the rows (records) of the GridView and store the ProductNumber
            // for each row that is checked

            for (int row = 0; row < gvItems.Rows.Count; row++)
            {
                CheckBox CBox;
                // Get the reference for the chkSelect control in the current row

                CBox = (CheckBox)gvItems.Rows[row].FindControl("chkSelect");
                if (CBox.Checked)

                {
                    String ItemID = "";
                    // Get the ProductNumber from the BoundField from the GridView for the current row

                    // and store the value in the array of selected products.

                    ItemID = gvItems.Rows[row].Cells[1].Text;
                    arrProducts.Add(ItemID);
                    count = count + 1;

                }

            }


            foreach (string s in arrProducts)
            {

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPAddItemsToMenu";

                objCommand.Parameters.AddWithValue("@MenuID", txtMenuID.Text.ToString());
                objCommand.Parameters.AddWithValue("@MenuName", txtMenuTitle.Text.ToString());

                //objCommand.Parameters[0].Value = s;
                objCommand.Parameters.AddWithValue("@ItemID", s);
                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                if (ResponseReceived == 1)
                {

                    lblConfirm.Text = "Thank you for creating an Menu!";
                    lblConfirm.Visible = true;
                }


                else
                {

                    lblConfirm.Text = "Failed";
                    lblConfirm.Visible = true;

                }
            }

            //var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
        }

        protected void ddlEditMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditItem.Visible = true;

            DBConnect objdb = new DBConnect();

            string selectedItem = ddlEditMenus.SelectedValue;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetMenusByMenuID";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@MenuID", selectedItem);

            DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

            int MenuID = (int)objDB.GetField("MenuID", 0);
            txtMenuID.Text = MenuID.ToString();
            txtMenuName1.Text = (string)objDB.GetField("MenuName", 0);
            txtMenuDescription1.Text = (string)objDB.GetField("MenuDesc", 0);
            txtMenuImgUrl.Text = (string)objDB.GetField("ImgUrl", 0);






        }

        protected void btnEditMenus_Click(object sender, EventArgs e)
        {
            ValidateEditMenu();
            if (UpdateInformationError.Count == 0)
            {

                string MenuName = txtMenuName1.Text;
                string ImgUrl = txtMenuDescription1.Text;
                string MenuDesc = txtMenuImgUrl.Text;
                int MenuID = int.Parse(txtMenuID.Text);

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPUpdateMenuInfo";


                objCommand.Parameters.AddWithValue("@MenuID", MenuID);
                objCommand.Parameters.AddWithValue("@MenuName", MenuName);
                objCommand.Parameters.AddWithValue("@ImgUrl", ImgUrl);
                objCommand.Parameters.AddWithValue("@MenuDesc", MenuDesc);


                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                if (ResponseReceived == 1)
                {
                    objCommand.Parameters.Clear();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TPUpdateItemsMenuInfo";

                    objCommand.Parameters.AddWithValue("@MenuID", MenuID);
                    objCommand.Parameters.AddWithValue("@MenuName", MenuName);

                    var ResponseReceived1 = objDB.DoUpdateUsingCmdObj(objCommand);

                    ViewAndEditItems.Visible = false;
                    lblConfirm.Text = "Thank you for updating your items!";
                    lblConfirm.Visible = true;
                    ddlAddOrRemove.Visible = true;
                }

            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    lblConfirm.Text = "Failed";
                    lblConfirm.Visible = true;
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
        }

        protected void ddlAddOrRemove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAddOrRemove.SelectedValue == "Add")
            {
                divAdd.Visible = true;
                divRemove.Visible = false;

                String strSQL2 = "SELECT * FROM TPItems where RestaurantID=" + Session["userid"].ToString() + "AND MenuID IS NULL;";

                gvAddMenuItems.DataSource = objDB.GetDataSet(strSQL2);
                gvAddMenuItems.DataBind();

            }
            if (ddlAddOrRemove.SelectedValue == "Remove")
            {
                divAdd.Visible = false;
                divRemove.Visible = true;

                int MenuID = int.Parse(ddlEditMenus.SelectedValue);
                String strSQL = "SELECT * FROM TPItems where RestaurantID=" + Session["userid"].ToString() + "AND MenuID =" + MenuID + ";";

                gvRemoveMenuItems.DataSource = objDB.GetDataSet(strSQL);
                gvRemoveMenuItems.DataBind();
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                ArrayList arrProducts = new ArrayList();    // used to store the ProductNumber for each selected product
                int count = 0;                              // used to count the number of selected products
                                                            // Iterate through the rows (records) of the GridView and store the ProductNumber
                                                            // for each row that is checked

                for (int row = 0; row < gvAddMenuItems.Rows.Count; row++)
                {
                    CheckBox CBox;
                    // Get the reference for the chkSelect control in the current row

                    CBox = (CheckBox)gvAddMenuItems.Rows[row].FindControl("chkSelect1");
                    if (CBox.Checked)

                    {
                        String ItemID = "";
                        // Get the ProductNumber from the BoundField from the GridView for the current row

                        // and store the value in the array of selected products.

                        ItemID = gvAddMenuItems.Rows[row].Cells[1].Text;
                        arrProducts.Add(ItemID);
                        count = count + 1;

                    }

                }

                foreach (string s in arrProducts)
                {

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TPAddItemsToMenu";

                    objCommand.Parameters.AddWithValue("@MenuID", ddlEditMenus.SelectedValue);
                    objCommand.Parameters.AddWithValue("@MenuName", txtMenuName1.Text.ToString());

                    //objCommand.Parameters[0].Value = s;
                    objCommand.Parameters.AddWithValue("@ItemID", s);
                    var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                    objCommand.Parameters.Clear();
                    if (ResponseReceived == 1)
                    {

                        lblConfirm.Text = "Thank you for Editing an Menu!";
                        lblConfirm.Visible = true;
                    }


                    else
                    {

                        lblConfirm.Text = "Failed";
                        lblConfirm.Visible = true;

                    }
                }
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
           
            ArrayList arrProducts = new ArrayList();    // used to store the ProductNumber for each selected product
            int count = 0;                              // used to count the number of selected products
                                                        // Iterate through the rows (records) of the GridView and store the ProductNumber
                                                        // for each row that is checked

            for (int row = 0; row < gvRemoveMenuItems.Rows.Count; row++)
            {
                CheckBox CBox;
                // Get the reference for the chkSelect control in the current row

                CBox = (CheckBox)gvRemoveMenuItems.Rows[row].FindControl("chkSelect2");
                if (CBox.Checked)

                {
                    String ItemID = "";
                    // Get the ProductNumber from the BoundField from the GridView for the current row

                    // and store the value in the array of selected products.

                    ItemID = gvRemoveMenuItems.Rows[row].Cells[1].Text;
                    arrProducts.Add(ItemID);
                    count = count + 1;

                }

            }

            foreach (string s in arrProducts)
            {

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPRemoveItemsFromMenu";

                objCommand.Parameters.AddWithValue("@MenuID", ddlEditMenus.SelectedValue);
                objCommand.Parameters.AddWithValue("@MenuName", txtMenuName1.Text.ToString());

                //objCommand.Parameters[0].Value = s;
                objCommand.Parameters.AddWithValue("@ItemID", s);
                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                if (ResponseReceived == 1)
                {

                    lblConfirm.Text = "Thank you for Editing an Menu!";
                    lblConfirm.Visible = true;
                }


                else
                {

                    lblConfirm.Text = "Failed";
                    lblConfirm.Visible = true;

                }
            }
        }
    }
}
