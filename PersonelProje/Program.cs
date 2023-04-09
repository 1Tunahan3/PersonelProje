using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonelProje
{
    internal class Program
    {



        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Sehirleri Listeleme: 1");
            Console.WriteLine("Sehirleri Ekleme: 2");
            Console.WriteLine("Sehirleri Güncelleme: 3");
            Console.WriteLine("Sehirleri Silme: 4");
            Console.WriteLine("Sehirleri Tek Listeleme: 5");

            int choice = Convert.ToInt32(Console.ReadLine());

            void ListCities()
            {
                

                var sehirler = Connect().Query<Sehir>("select * from sehir").ToList();

                foreach (var item in sehirler)
                {
                    //Console.WriteLine($"{item.Id} - {item.SehirIsim}");
                    //verilen isim sql içindeki isimle aynı olmak zorunda bu sekilde yaparsak null deger atar

                    Console.WriteLine($"{item.Id} - {item.SehirAd}");
                }

                Console.WriteLine("Devam İçin Enter");
                Console.ReadLine();
                Main();
            }

                void ListACity()
                {
                //Console.WriteLine("Plaka no girin");                    İLKEL HALİ
                //string Id=Convert.ToString(Console.ReadLine());

                //string Id = GetFromUser("Plaka No Girin");  Query Sehir içindeki ID= alanıdna methodu çağırdık daha kısa oldu



                // var con2= Connect();
                //  ARA DEĞİŞKEN KULLANARAK KISALTILMIŞ HALİ
                //var city = con2.Query<Sehir>($"Select * from Sehir where Id={Id}").First();


                var city = Connect().Query<Sehir>($"Select * from Sehir where Id={GetFromUser("Plaka No Girin")}").First();
                Console.WriteLine($"{city.Id}--- {city.SehirAd}");
                Console.ReadLine();
                    Main();

                }


            void DeleteCity()
            {

                //Console.WriteLine("Plaka no girin");
                //string Id = Convert.ToString(Console.ReadLine());     İLKEL HALİ

                //string Id = GetFromUser("Plaka No girin");   Query Sehir içindeki ID= alanıdna methodu çağırdık daha kısa oldu

                //var con3 = Connect();
                // con3.ExecuteScalar<Sehir>($"Delete from Sehir where Id={Id}");


                Connect().ExecuteScalar<Sehir>($"Delete from Sehir where Id={GetFromUser("Plaka No girin")}");
                Console.WriteLine("Siliniyor......");
                ListCities();
                Main();
            }

            void UpdateCity()
            {
                //Console.WriteLine("Plaka no girin");
                //string Id = Convert.ToString(Console.ReadLine());   İLKEL HALİ

                //string Id = GetFromUser("Plaka no girin");        Query Sehir içindeki ID= alanıdna methodu çağırdık daha kısa oldu
                //string Name = GetFromUser("Sehir adını girin");  Query Sehir içindeki ID= alanıdna methodu çağırdık daha kısa oldu

                //Console.WriteLine("Sehir adını girin");
                //string Name = Convert.ToString(Console.ReadLine());

                //var con3 = Connect();
                //con3.ExecuteScalar<int>($"Update Sehir set SehirAd ='{Name}' where Id='{Id}'");

                Connect().ExecuteScalar<int>($"Update Sehir set SehirAd ='{GetFromUser("Sehir adını girin")}' where Id='{GetFromUser("Plaka no girin")}'");

                ListCities();

                Main();
            }

            void InsertCity()
            {
                //Console.WriteLine("Plaka no girin");
                //string Id = Convert.ToString(Console.ReadLine());   İLKEL HALİ
                //Console.WriteLine("Sehir adını girin");
                //string Name = Convert.ToString(Console.ReadLine());


                //string Id = GetFromUser("Plaka no girin");        Query Sehir içindeki ID= alanıdna methodu çağırdık daha kısa oldu
                //string Name = GetFromUser("Sehir Adı Girin");       Query Sehir içindeki ID= alanıdna methodu çağırdık daha kısa oldu



                //var con3 = Connect();
                //con3.ExecuteScalar<int>($"Insert Into Sehir (SehirAd ,Id) Values('{Name}',{Id})");

                Connect().ExecuteScalar<int>($"Insert Into Sehir (SehirAd ,Id) Values('{GetFromUser("Sehir Adı Girin")}',{GetFromUser("Plaka no girin")})");

                ListCities();

                Main();
            }

            SqlConnection Connect()
            {
                return new SqlConnection(@"Server = LAPTOP-O8NNVRJQ; Database=Sehirler; Trusted_Connection=true;");

            }

            string GetFromUser(string question)
            {
                Console.WriteLine(question);
                return Convert.ToString(Console.ReadLine());
            }

            if (choice == 1) ListCities();
            else if (choice == 5) ListACity();
            else if (choice == 4) DeleteCity();
            else if (choice == 3) UpdateCity();
            else if (choice == 2) InsertCity();


            }
        }
    }

