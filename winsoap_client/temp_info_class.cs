using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winsoap_client
{
    class temp_info_class
    {
                                               //Конструктор
        public temp_info_class()
        {
            country_id = new List<string>(); //country_id.Add("0");
            country_iso3 = new List<string>(); //country_iso3.Add("ISO3_0");
            country_name = new List<string>(); //country_name.Add("Выберите страну...");

            city_id = new List<string>(); //city_id.Add("0");
            city_code = new List<string>(); //city_code.Add("city_code_0");
            city_name = new List<string>(); //city_name.Add("Выберите город...");

            hotel_id = new List<string>(); //hotel_id.Add("0");
            hotel_code = new List<string>(); //hotel_code.Add("hotel_code_0");
            hotel_name = new List<string>(); //hotel_name.Add("Выберите отель...");
            hotel_category_name = new List<string>(); //hotel_category_name.Add("hotel_category_name_0");

            specialoffer_id = new List<string>(); //specialoffer_id.Add(0);
            specialoffer_code = new List<string>(); //specialoffer_code.Add("Выберите special offer");

            created_id = new List<string>(); //
            created = new List<string>(); //
            
            
            period_id = new List<string>(); //period_id.Add(0);
            period_start = new List<string>(); //period_start.Add(new DateTime(1, 1, 1));
            period_end = new List<string>(); //period_end.Add(new DateTime(1, 1, 1));
            
            bookingperiod_id = new List<string>(); //bookingperiod_id.Add(0);
            bookingperiod_start = new List<string>(); //bookingperiod_start.Add(new DateTime(1, 1, 1));
            bookingperiod_end = new List<string>(); //bookingperiod_end.Add(new DateTime(1, 1, 1));

            
        }


                                                                                //ABBR



                                              //COUNTRY
        private List<string> country_id;
        public List<string> Country_ID
        {
            get { return country_id; }
            set { country_id = value; }
        }

        private List<string> country_iso3;
        public List<string> Country_ISO3
        {
            get { return country_iso3; }
            set { country_iso3 = value; }
        }
        private List<string> country_name;
        public List<string> Country_Name
        {
            get { return country_name; }
            set { country_name = value; }
        }

        public void Add_Countries_Range(List<string[]> tmp)
        {
            country_id.Add("0");
            country_iso3.Add("ISO3_0");
            country_name.Add("Выберите страну...");
            for(int i = 0; i < tmp.Count; i++)
            {
                this.country_id.Add(tmp[i][0]); this.country_iso3.Add(tmp[i][1]); this.country_name.Add(tmp[i][2]);
            }
             
        }

                                                     //CITIES
        private List<string> city_id;
        public List<string> City_ID
        {
            get { return city_id; }
            set { city_id = value; }
        }
        
        private List<string> city_code;
        public List<string> City_Code
        {
            get { return city_code; }
            set { city_code = value; }
        }

        private List<string> city_name;
        public List<string> City_Name
        {
            get { return city_name; }
            set { city_name = value; }
        }

        public void Add_Cities_Range(List<string[]> tmp)
        {
            city_id.Add("0");
            city_code.Add("city_code_0");
            city_name.Add("Выберите город...");
            for (int i = 0; i < tmp.Count; i++)
            {
                this.city_id.Add(tmp[i][0]); this.city_code.Add(tmp[i][1]); this.city_name.Add(tmp[i][2]);
            }

        }

        public void Delete_Cities()
        {
            this.city_id = new List<string>(); 
            this.city_code = new List<string>(); 
            this.city_name = new List<string>(); 
        }

                                                           //HOTELS
        private List<string> hotel_id;
        public List<string> Hotel_ID
        {
            get { return hotel_id; }
            set { hotel_id = value; }
        }

        private List<string> hotel_code;
        public List<string> Hotel_Code
        {
            get { return hotel_code; }
            set { hotel_code = value; }
        }

        private List<string> hotel_name;
        public List<string> Hotel_Name
        {
            get { return hotel_name; }
            set { hotel_name = value; }
        }

        private List<string> hotel_category_name;
        public List<string> Hotel_Category_Name
        {
            get { return hotel_category_name; }
            set { hotel_category_name = value; }
        }

        public void Add_Hotels_Range(List<string[]> tmp)
        {
            hotel_id.Add("0");
            hotel_code.Add("hotel_code_0");
            hotel_name.Add("Выберите отель...");
            hotel_category_name.Add("hotel_category_name_0");
            for (int i = 0; i < tmp.Count; i++)
            {
                this.hotel_id.Add(tmp[i][0]); this.hotel_code.Add(tmp[i][1]); this.hotel_name.Add(tmp[i][2]); this.hotel_category_name.Add(tmp[i][3]);
            }
        }

        public void Delete_Hotels()
        {
            this.hotel_id = new List<string>(); 
            this.hotel_code = new List<string>(); 
            this.hotel_name = new List<string>(); 
            this.hotel_category_name = new List<string>(); 
        }


                                                                //SPECIALOFFER
        private List<string> specialoffer_id;
        public List<string> Specialoffer_ID
        {
            get { return specialoffer_id; }
            set { specialoffer_id = value; }
        }
        
        private List<string> specialoffer_code;
        public List<string> Specialoffer_Code
        {
            get { return specialoffer_code; }
            set { specialoffer_code = value; }
        }

        public void Add_Specialoffer_Range(List<string[]> tmp)
        {
            specialoffer_id.Add("0");
            specialoffer_code.Add("Выберите specialoffer...");
            for (int i = 0; i < tmp.Count; i++)
            {
                this.specialoffer_id.Add(tmp[i][0]); this.specialoffer_code.Add(tmp[i][1]);
            }
        }

        public void Delete_Specialoffer()
        {
            this.specialoffer_id = new List<string>(); 
            this.specialoffer_code = new List<string>();  
        }
                                                                                       //CREATED
        private List<string> created_id;
        public List<string> Created_ID
        {
            get { return created_id; }
            set { created_id = value; }
        }

        private List<string> created;
        public List<string> Created
        {
            get { return created; }
            set
            {
                created.Add("Выберите дату создания цен...");
                created.AddRange(value);
            }
        }

        public void Delete_Created()
        {
            this.created_id = new List<string>();
            this.created = new List<string>();
        }




                                                                                           //PERIODS
        private List<string> period_id;
        public List<string> Period_ID
        {
            get { return period_id; }
            set { period_id = value; }
        }

        private List<string> period_start;
        public List<string> Period_Start
        {
            get { return period_start; }
            set
            {
                period_start.Add("Выберите начало периода...");
                period_start.AddRange(value);
            }
        }

        private List<string> period_end;
        public List<string> Period_End
        {
            get { return period_end; }
            set
            {
                period_end.Add("Выберите конец периода...");
                period_end.AddRange(value);
            }
        }

        public void Delete_Periods()
        {
            this.period_id = new List<string>();
            this.period_start = new List<string>();
            this.period_end = new List<string>();
        }

        public void Delete_Periods_end()
        {
            this.period_end = new List<string>();
        }
                                                                           //BOOKINGPERIOD
        private List<string> bookingperiod_id;
        public List<string> Bookingperiod_ID
        {
            get { return bookingperiod_id; }
            set { bookingperiod_id = value; }
        }
        
        private List<string> bookingperiod_start;
        public List<string> Bookingperiod_Start
        {
            get { return bookingperiod_start; }
            set 
            {
                bookingperiod_start.Add("Выберите начало Bookingperiod...");
                bookingperiod_start.AddRange(value); 
            }
        }

        private List<string> bookingperiod_end;
        public List<string> Bookingperiod_End
        {
            get { return bookingperiod_end; }
            set 
            {
                bookingperiod_end.Add("Выберите конец Bookingperiod...");
                bookingperiod_end.AddRange(value); 
            }
        }

        public void Delete_Bookingperiods()
        {
            this.bookingperiod_id = new List<string>();
            this.bookingperiod_start = new List<string>();
            this.bookingperiod_end = new List<string>();
        }

        public void Delete_Bookingperiods_end()
        {
            this.bookingperiod_end = new List<string>();
        }

                                                                                                //ABBR_CODES_OF_ROOMS
        
        

    }
}
