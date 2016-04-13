using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using winsoap_dal;
using System.Configuration;
using System.IO;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace winsoap_client
{
    public partial class Form1 : Form
    {
        //for sort periodbegin
        List<int> indexperiodend = new List<int>();
        //**********
        Dictionary<string, string> accoms_changed;
        //for sort
        List<DateTime[,]> periods = new List<DateTime[,]>();
        List<string> cities = new List<string>();
        List<string> roomtypes = new List<string>();
        List<string> mealtypes = new List<string>();
        List<string> accoms = new List<string>();
        //_________
        List<string> selected_values = new List<string>();

        List<string[]> abbr_list = new List<string[]>();
        //**************
        


        //**************
        
        temp_info_class tmp_class = new temp_info_class();

        winsoap_dal.winsoap_conn_dal win_conn_dal = new winsoap_conn_dal();

        SqlConnectionStringBuilder sql_builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["sql_provider1"].ConnectionString);
        

        int company_id = Properties.Settings.Default.id_company_in_BD;
        public Form1()
        {
            InitializeComponent();

            design_form();

            sql_builder.UserID = "tarif_client";
            sql_builder.Password = "Qwerty12";

            noactive_cmbbox();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

            win_conn_dal.OpenConnection(sql_builder.ConnectionString);
            tmp_class.Add_Countries_Range(win_conn_dal.select_countries(Properties.Settings.Default.id_company_in_BD));
            cmbbox_country.Items.AddRange(tmp_class.Country_Name.ToArray());

            abbr_list.AddRange(win_conn_dal.select_abbr(Properties.Settings.Default.id_company_in_BD));
            win_conn_dal.CloseConnection();
            cmbbox_country.SelectedIndex = 1;
            chckbx_period_till.Checked = true;

            
        }

        

        private void btn_start_Click_(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void design_form()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Label)
                {
                    this.Controls[i].Font = new System.Drawing.Font("Candara", 9.5F, System.Drawing.FontStyle.Bold);
                    if (this.Controls[i].Name.Equals("lbl_title"))
                    {
                        this.Controls[i].Font = new System.Drawing.Font("Constantia", 14F, System.Drawing.FontStyle.Bold);
                    }
                }
            }

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Button)
                {
                    this.Controls[i].Font = new System.Drawing.Font("Candara", 9.5F, System.Drawing.FontStyle.Bold);
                }
            }

        }

        private void noactive_cmbbox()
        {
            cmbbox_city.Enabled = false;
            cmbbox_hotel.Enabled = false;
            cmbbox_specialoffer.Enabled = false;
            cmbbox_created.Enabled = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }
       
        private void btn_start_Click(object sender, EventArgs e)
        {
            main_work();
        }

        private void main_work()
        {
            

            if (cmbbox_hotel.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите отель");
                return;
            }
            else
            {
                if (cmbbox_specialoffer.SelectedIndex <= 0)
                {
                    MessageBox.Show("Выберите Specialoffer");
                    return;
                }
            }

            btn_start.Enabled = false;
            btn_toexcel.Enabled = false;



            if (data_gr_1.Rows.Count != 0)
            {
                while (data_gr_1.Rows.Count != 0)
                    data_gr_1.Rows.RemoveAt(0);
                while (data_gr_1.Columns.Count != 0)
                    data_gr_1.Columns.RemoveAt(0);
            }
            else
            {
                while (data_gr_1.Columns.Count != 0)
                    data_gr_1.Columns.RemoveAt(0);
            }
            data_gr_1.Refresh();


            alkhalidiah_reference.HotelPricesRequest hotelprreq = new alkhalidiah_reference.HotelPricesRequest();
            alkhalidiah_reference.User requestor = new alkhalidiah_reference.User();
            requestor.Login = "login";
            requestor.Password = "password";
            
            requestor.Name = "name";
            hotelprreq.Requestor = requestor;

            alkhalidiah_reference.HotelPriceCondition hotelprcond_0 = new alkhalidiah_reference.HotelPriceCondition();

            //CITY
            alkhalidiah_reference.ReferenceCondition refcond_city_0 = new alkhalidiah_reference.ReferenceCondition();
            refcond_city_0.Name = cmbbox_city.SelectedItem.ToString();
            hotelprcond_0.City = refcond_city_0;
            //HOTEL
            alkhalidiah_reference.ReferenceCondition refcond_hotel_0 = new alkhalidiah_reference.ReferenceCondition();
            refcond_hotel_0.Name = cmbbox_hotel.SelectedItem.ToString();
            hotelprcond_0.Hotel = refcond_hotel_0;
            //CREATED
            alkhalidiah_reference.DurationPeriod refcond_created_0 = new alkhalidiah_reference.DurationPeriod();

            if (!(((cmbx_item)(cmbbox_created.SelectedItem)).Value_Text.Equals("0")))
            {
                refcond_created_0.Begin = DateTime.Parse(((cmbx_item)(cmbbox_created.SelectedItem)).Value_Text);
                refcond_created_0.BeginSpecified = true;
                refcond_created_0.End = DateTime.Parse(((cmbx_item)(cmbbox_created.SelectedItem)).Value_Text).AddDays(1);
                refcond_created_0.EndSpecified = true;
                hotelprcond_0.Created = refcond_created_0;
            }

            
            

            hotelprreq.Conditions = new alkhalidiah_reference.HotelPriceCondition[1];
            hotelprreq.Conditions[0] = hotelprcond_0;

            //HOTELPRICERESPONSE
            alkhalidiah_reference.HotelPricesResponse hotelprresp = new alkhalidiah_reference.HotelPricesResponse();

            alkhalidiah_reference.ExchangeServiceSoapClient servicesoap_client = new alkhalidiah_reference.ExchangeServiceSoapClient();


            hotelprresp = servicesoap_client.HotelPricesRQ(hotelprreq);
            
            

            if (hotelprresp.Errors != null)
            {
                using (StreamWriter strwrite = File.AppendText("log.txt"))
                {
                    foreach (alkhalidiah_reference.Warning er in hotelprresp.Errors)
                    {
                        strwrite.Write(DateTime.Now.ToLongTimeString() + "    Error code: " + er.Code + ";    Error value:    " + er.Value + ";   ");
                        if (er.Code == 0)
                        {
                            strwrite.WriteLine("Проверьте правильность логина и пароля");
                        }
                    }
                }
                return;
            }

            if (hotelprresp.Prices == null)
            {
                btn_start.Enabled = true;
                btn_toexcel.Enabled = true;
                return;
            }



            foreach (alkhalidiah_reference.HotelPrice hotelpr in hotelprresp.Prices)
            {
                if (hotelpr.SpecialOffer.Code.Equals(((cmbx_item)(cmbbox_specialoffer.SelectedItem)).Value_Text))
                {

                    if (!periods.Exists(t => (t[0, 0] == hotelpr.Period.Begin) & (t[1, 0] == hotelpr.Period.End)))
                    {
                        periods.Add(new[,] { { hotelpr.Period.Begin }, { hotelpr.Period.End } });
                    }
                    if (!roomtypes.Exists(t => t.Equals(hotelpr.Room.Category.Name)))
                    {
                        roomtypes.Add(hotelpr.Room.Category.Name);
                    }
                    if (!mealtypes.Exists(t => t.Equals(hotelpr.MealType.Code)))
                    {
                        mealtypes.Add(hotelpr.MealType.Code);
                    }

                    if (!accoms.Exists(t => t.Equals(hotelpr.Room.Accommodation.Code)))
                    {
                        accoms.Add(hotelpr.Room.Accommodation.Code);
                    }
                }
                else { continue; }
            }

            data_gr_1.Columns.Add("period_begin", "Period from");
            data_gr_1.Columns.Add("period_end", "Period till");
            data_gr_1.Columns.Add("booking_period_begin", "Booking from");
            data_gr_1.Columns.Add("booking_period_end", "Booking till");
            data_gr_1.Columns.Add("room_type", "Room type");
            data_gr_1.Columns.Add("meal", "Meal");
            data_gr_1.Columns.Add("freenights", "Nights");

            var abbr_list_sorted = abbr_list.OrderBy(item => item[2]);




            accoms_changed = change_accoms(accoms, abbr_list_sorted);

            foreach (KeyValuePair<string, string> kvp in accoms_changed)
            {
                data_gr_1.Columns.Add(kvp.Key, kvp.Key+"\n"+kvp.Value);
            }
            

            int data_gr_count_rows = periods.Count * roomtypes.Count * mealtypes.Count;

            if (data_gr_count_rows == 0)
            {
                btn_start.Enabled = true;
                btn_toexcel.Enabled = true;
                return;
            }
            data_gr_1.Rows.Add(data_gr_count_rows);


            int index_row;


            indexperiodend.Clear();

            foreach (alkhalidiah_reference.HotelPrice hotelpr in hotelprresp.Prices)
            {
                
                index_row = periods.Count * mealtypes.Count * (roomtypes.FindIndex(t => t.Equals(hotelpr.Room.Category.Name))) +
                               (periods.FindIndex(t => (t[0, 0] == hotelpr.Period.Begin) & (t[1, 0] == hotelpr.Period.End))) * mealtypes.Count +
                               mealtypes.FindIndex(t => t.Equals(hotelpr.MealType.Code));
                if (index_row < 0) { continue; }
                if (hotelpr.Period.End < DateTime.Now)
                {
                    if (indexperiodend.IndexOf(index_row) < 0)
                    {
                        indexperiodend.Add(index_row);
                    }
                }

                data_gr_1.Rows[index_row].Cells[0].Value = hotelpr.Period.Begin;
                data_gr_1.Rows[index_row].Cells[1].Value = hotelpr.Period.End;

                data_gr_1.Rows[index_row].Cells[2].Value = hotelpr.BookingPeriod.Begin;
                if (!hotelpr.BookingPeriod.End.Equals(DateTime.MinValue))
                {
                    data_gr_1.Rows[index_row].Cells[3].Value = hotelpr.BookingPeriod.End;
                }
                else
                {
                    data_gr_1.Rows[index_row].Cells[3].Value = "-";
                }
                data_gr_1.Rows[index_row].Cells[4].Value = string.Copy(hotelpr.Room.Category.Name);
                data_gr_1.Rows[index_row].Cells[5].Value = string.Copy(hotelpr.MealType.Code);
                data_gr_1.Rows[index_row].Cells[6].Value = "1";
                data_gr_1.Rows[index_row
                                  ].Cells[hotelpr.Room.Accommodation.Code].Value = ((int)hotelpr.Amount).ToString();

            }

            periods = new List<DateTime[,]>();
            cities.Clear();
            roomtypes.Clear();
            mealtypes.Clear();
            accoms.Clear();

            int int_count = -1;
            do
            {
                int_count++;
                if ((data_gr_1.Rows[int_count].Cells[0].Value == null) || (data_gr_1.Rows[int_count].Cells[0].Value.ToString().Equals("")))
                {
                    data_gr_1.Rows.RemoveAt(int_count);
                    int_count = -1;
                }

            }
            while ((data_gr_1.Rows.Count - 1) != int_count);
            chckbx_period_till_CheckedChanged(null, null);
            data_gr_1.AutoResizeColumns();

            btn_start.Enabled = true;
            btn_toexcel.Enabled = true;
            chckbx_period_till.Checked = true;
        }

        private Dictionary<string,string> change_accoms(List<string> accoms, IOrderedEnumerable<string[]> abbr_list_sorted)
        {
            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);

            Regex regex_abbr = new Regex(@"(\(\d+\-(\d+)\))(\(\d+\-(\d+)\))?.*");


            List<string> result = new List<string>(accoms);
            Dictionary<string,string> result2 = new Dictionary<string,string>();
            foreach (string str in result)
            {
                foreach (string[] s in abbr_list_sorted)
                {
                    if (str.Contains(s[0]))
                    {
                        //str.Replace(s[0], s[1]);
                        result2.Add(str,regex_abbr.Replace(str.Replace(s[0], s[1]),myEvaluator));
                        break;
                    }
                }
            }
            return result2;
        }

        private string ReplaceCC(Match match)
        {
            string st1 = "";
            for (int i = 0; i <= match.Groups.Count; i++)
            {
                if (match.Groups[3].Value.Equals(""))
                {
                    st1 = match.Groups[1].Value.Replace(match.Groups[2].Value, (Convert.ToInt32(match.Groups[2].Value) + 1).ToString());
                    break;
                }

                if (match.Groups[1].Value.Equals(match.Groups[3].Value))
                {
                    st1 = match.Groups[1].Value.Replace(match.Groups[2].Value, (Convert.ToInt32(match.Groups[2].Value) + 1).ToString());
                }

                else
                {
                    st1 = match.Groups[1].Value.Replace(match.Groups[2].Value, (Convert.ToInt32(match.Groups[2].Value) + 1).ToString())
                        + match.Groups[3].Value.Replace(match.Groups[4].Value, (Convert.ToInt32(match.Groups[4].Value) + 1).ToString());
                }
            }

            return st1;

        }

        private void cmbbox_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbox_country.SelectedIndex == 0)
                return;

            tmp_class.Delete_Cities(); cmbbox_city.Items.Clear(); cmbbox_city.Enabled = true;
            tmp_class.Delete_Hotels(); cmbbox_hotel.Items.Clear(); cmbbox_hotel.Enabled = false;
            tmp_class.Delete_Specialoffer(); cmbbox_specialoffer.Enabled = false;
            tmp_class.Delete_Created();

            win_conn_dal.OpenConnection(sql_builder.ConnectionString);

            tmp_class.Add_Cities_Range(win_conn_dal.select_cities(company_id, tmp_class.Country_ID[cmbbox_country.SelectedIndex]));
            cmbbox_city.Items.AddRange(tmp_class.City_Name.ToArray());
            win_conn_dal.CloseConnection();
            cmbbox_city.SelectedItem = "Sharjah";
        }

        private void cmbbox_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbox_city.SelectedIndex == 0)
                return;
            tmp_class.Delete_Hotels(); cmbbox_hotel.Items.Clear(); cmbbox_hotel.Enabled = true;
            tmp_class.Delete_Specialoffer(); cmbbox_specialoffer.Enabled = false;
            tmp_class.Delete_Created();



            win_conn_dal.OpenConnection(sql_builder.ConnectionString);
            tmp_class.Add_Hotels_Range(win_conn_dal.select_hotels(company_id, tmp_class.Country_ID[cmbbox_country.SelectedIndex],
                                                                              tmp_class.City_ID[cmbbox_city.SelectedIndex]));
            cmbbox_hotel.Items.AddRange(tmp_class.Hotel_Name.ToArray());
            win_conn_dal.CloseConnection();
            cmbbox_hotel.SelectedItem = "Выберите отель...";
        }
        private void cmbbox_hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbox_hotel.SelectedIndex == 0)
            {
                return;
            }
            tmp_class.Delete_Specialoffer(); cmbbox_specialoffer.Enabled = true;
            tmp_class.Delete_Created();


            win_conn_dal.OpenConnection(sql_builder.ConnectionString);

            tmp_class.Add_Specialoffer_Range(win_conn_dal.select_specialoffers(company_id, tmp_class.Country_ID[cmbbox_country.SelectedIndex],
                                                                                           tmp_class.City_ID[cmbbox_city.SelectedIndex],
                                                                                           tmp_class.Hotel_ID[cmbbox_hotel.SelectedIndex]));
            ArrayList cmb_items = new ArrayList();
            foreach (string element in tmp_class.Specialoffer_Code)
            {
                if (element.Equals(""))
                    cmb_items.Add(new cmbx_item("CONTRACT RATES", ""));
                else cmb_items.Add(new cmbx_item(element, element));
            }

            cmbbox_specialoffer.DataSource = cmb_items;
            cmbbox_specialoffer.DisplayMember = "Disp_Text";
            cmbbox_specialoffer.ValueMember = "Value_Text";


            win_conn_dal.CloseConnection();
            cmbbox_specialoffer.SelectedItem = "Выберите specialoffer...";
        }

        
        private void cmbbox_specialoffer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbox_specialoffer.SelectedIndex == 0)
            {
                return;
            }
            tmp_class.Delete_Created(); cmbbox_created.Enabled = true;

            win_conn_dal.OpenConnection(sql_builder.ConnectionString);

            tmp_class.Created = (win_conn_dal.select_created(company_id, tmp_class.Country_ID[cmbbox_country.SelectedIndex],
                                                                                           tmp_class.City_ID[cmbbox_city.SelectedIndex],
                                                                                           tmp_class.Hotel_ID[cmbbox_hotel.SelectedIndex],
                                                                                           tmp_class.Specialoffer_ID[cmbbox_specialoffer.SelectedIndex]));


            ArrayList cmb_items = new ArrayList();


            foreach (string element in tmp_class.Created)
            {
                if (element.Equals("Выберите дату создания цен..."))
                {
                    cmb_items.Add(new cmbx_item(element, "0"));

                }
                else
                {
                    if (element.Equals(""))
                        cmb_items.Add(new cmbx_item(DateTime.Today.ToShortDateString(), null));
                    else cmb_items.Add(new cmbx_item(element, element));
                }
            }


            cmbbox_created.DataSource = cmb_items;
            cmbbox_created.DisplayMember = "Disp_Text";
            cmbbox_created.ValueMember = "Value_Text";


            win_conn_dal.CloseConnection();
            cmbbox_created.SelectedItem = "Выберите дату создания цен...";

        }

        

        private void btn_toexcel_Click(object sender, EventArgs e)
        {
            

            if (data_gr_1.Rows.Count == 0)
            {
                return;
            }

            Excel.Application ExcelApp = new Excel.Application();
            Excel.Range excelcell;
            Excel.Range excelcell2;
            ExcelApp.SheetsInNewWorkbook = 1;
            ExcelApp.Workbooks.Add(Type.Missing);

            ExcelApp.Cells[1, 1] = cmbbox_hotel.SelectedItem;
            excelcell = ExcelApp.get_Range((Excel.Range)ExcelApp.Cells[2, 7], (Excel.Range)ExcelApp.Cells[1, data_gr_1.Columns.Count]);
            //excelcell.Font.Bold = true;
            excelcell.HorizontalAlignment = Excel.Constants.xlCenter;


            for (int j = 0; j < 7; j++)
            {
                ExcelApp.Cells[2, j + 1] = data_gr_1.Columns[j].HeaderText;
                
            }
            for (int j = 7; j < data_gr_1.Columns.Count; j++)
            {
                ExcelApp.Cells[2, j + 1] = accoms_changed[data_gr_1.Columns[j].Name];
            }

            excelcell.EntireColumn.AutoFit();

            //Номер строки с ячейками данных в экселе. С третьей строчки начнётся заполнение данных. Отсчёт в экселевских страницах ведётся с единицы.
            int indexrow = 3;
            for (int i = 0; i < data_gr_1.Rows.Count; i++)
            {
                if (data_gr_1.Rows[i].Visible)
                {
                    for (int j = 0; j < data_gr_1.Columns.Count; j++)
                    {
                        ExcelApp.Cells[indexrow, j + 1] = data_gr_1.Rows[i].Cells[j].Value;
                    }
                    indexrow++;
                }
                else
                {
                    continue;
                }
            }

            excelcell2 = ExcelApp.get_Range((Excel.Range)ExcelApp.Cells[3, 1], (Excel.Range)ExcelApp.Cells[data_gr_1.Rows.Count + 2, data_gr_1.Columns.Count + 1]);
            excelcell2.EntireColumn.AutoFit();
            excelcell2.HorizontalAlignment = Excel.Constants.xlCenter;

            ExcelApp.Visible = true;
        }

        private void chckbx_period_till_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0;i<data_gr_1.Rows.Count;i++)
            {
                if (chckbx_period_till.Checked)
                {
                    if (indexperiodend.IndexOf(i) > -1)
                    {
                        data_gr_1.Rows[i].Visible = false;
                    }
                }
                else 
                {
                    if (indexperiodend.IndexOf(i) > -1)
                    {
                        data_gr_1.Rows[i].Visible = true;
                    }
                }
            }
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (Form1.ActiveForm.Size.Width > 1600)
            {
                btn_start.Left = 1300;
                btn_start.Top = 103;
                btn_toexcel.Left = 1463;
                btn_toexcel.Top = 103;
            }
            else
            {
                btn_start.Left = 921;
                btn_start.Top = 156;
                btn_toexcel.Left = 1126;
                btn_toexcel.Top = 156;
            }
        }

        
    }    

    public class cmbx_item
    {
        private string disp_text;
        private string value_text;

        public cmbx_item(string strdisp_text, string strvalue_text)
        {

            this.disp_text = strdisp_text;
            this.value_text = strvalue_text;
        }

        public string Disp_Text
        {
            get
            {
                return disp_text;
            }
        }

        public string Value_Text
        {

            get
            {
                return value_text;
            }
        }
    }

}
