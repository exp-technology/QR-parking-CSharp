using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;
using System.Data.SQLite;

namespace BarCodeScannerApplication
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        public Form1()
        {
            InitializeComponent();
            timer4.Enabled = true;
            timer4.Start();
            
            label21.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        public bool satu_kali_start_scan;
        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            satu_kali_start_scan = false;
            if(satu_kali_start_scan == false)
            {
                timer3.Enabled = true;
                timer3.Start();
            }
            

        } 
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }

            comboBox1.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
            /*******************membuat semuanya memiliki backcolor transparent*********************/
            label1.Parent = pictureBox3;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox3;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox3;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox3;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox3;
            label5.BackColor = Color.Transparent;
            label6.Parent = pictureBox3;
            label6.BackColor = Color.Transparent;
            label7.Parent = pictureBox3;
            label7.BackColor = Color.Transparent;
            label8.Parent = pictureBox3;
            label8.BackColor = Color.Transparent;
            label9.Parent = pictureBox3;
            label9.BackColor = Color.Transparent;
            label10.Parent = pictureBox3;
            label10.BackColor = Color.Transparent;
            label11.Parent = pictureBox3;
            label11.BackColor = Color.Transparent;
            label12.Parent = pictureBox3;
            label12.BackColor = Color.Transparent;
            label13.Parent = pictureBox3;
            label13.BackColor = Color.Transparent;
            label14.Parent = pictureBox3;
            label14.BackColor = Color.Transparent;
            label15.Parent = pictureBox3;
            label15.BackColor = Color.Transparent;
            label16.Parent = pictureBox3;
            label16.BackColor = Color.Transparent;
            label17.Parent = pictureBox3;
            label17.BackColor = Color.Transparent;

            label18.Parent = pictureBox3;
            label18.BackColor = Color.Transparent;
            label19.Parent = pictureBox3;
            label19.BackColor = Color.Transparent;
            label20.Parent = pictureBox3;
            label20.BackColor = Color.Transparent;
            label21.Parent = pictureBox3;
            label21.BackColor = Color.Transparent;
            label22.Parent = pictureBox3;
            label22.BackColor = Color.Transparent;
            label23.Parent = pictureBox3;
            label23.BackColor = Color.Transparent;
            label24.Parent = pictureBox3;
            label24.BackColor = Color.Transparent;
            label25.Parent = pictureBox3;
            label25.BackColor = Color.Transparent;
            label26.Parent = pictureBox3;
            label26.BackColor = Color.Transparent;
            label27.Parent = pictureBox3;
            label27.BackColor = Color.Transparent;
            label28.Parent = pictureBox3;
            label28.BackColor = Color.Transparent;
            label29.Parent = pictureBox3;
            label29.BackColor = Color.Transparent;
            label30.Parent = pictureBox3;
            label30.BackColor = Color.Transparent;
            label31.Parent = pictureBox3;
            label31.BackColor = Color.Transparent;
            label32.Parent = pictureBox3;
            label32.BackColor = Color.Transparent;
            label33.Parent = pictureBox3;
            label33.BackColor = Color.Transparent;
            label34.Parent = pictureBox3;
            label34.BackColor = Color.Transparent;
            label35.Parent = pictureBox3;
            label35.BackColor = Color.Transparent;


            pictureBox1.Parent = pictureBox3;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox3;
            pictureBox2.BackColor = Color.Transparent;

            chart_pertamakali();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }
        public String pembacaan_lama;
        public String cari;
        public String tambah;
        public String hari_ini;
        public int tambahsatu;
        public String update;
        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode((Bitmap)pictureBox1.Image);
            try
            {
                hari_ini = DateTime.Now.ToString("dd/MM/yyyy");
                string decoded = result.ToString().Trim();
                if (decoded != "")
                {   /*********************************************************////
                    /* timer1.Stop(); jika dikomtar kan maka akan terus membaca
                    dan menenkripsi apa yang ada di kamera */
                    //MessageBox.Show(decoded);
                    //Form2 form = new Form2();
                    //form.Show();
                    //this.Hide();
                    // nilai timer sudah diganti dengan nilai 50 milisecond
                    //*********************************************************//////
                   // timer2.Stop();

                    if (decoded != pembacaan_lama)
                    {
                        
                        timer2.Stop();
                        //SQLiteConnection.CreateFile("data_aplikasi.db3");
                        //********************************************fungsi penampil********************************//

                        SQLiteConnection kon;
                        kon = new SQLiteConnection("Data Source  = data_aplikasi.db3;Version =3;");
                        kon.Open();
                        // SQLiteCommand perintah = new SQLiteCommand(buat_tabel, kon);
                        //perintah.ExecuteNonQuery();
                        

                        cari = String.Format("select * from data_kendaraan where code = '{0}'", decoded); //mencari data di sebuah database dengan parameternya sebuah variabel
                        SQLiteCommand perintah1 = new SQLiteCommand(cari, kon);
                        perintah1.ExecuteNonQuery();
                        SQLiteDataReader baca = perintah1.ExecuteReader();
                        // MessageBox.Show(baca.Read());
                        while (baca.Read())
                        {
                            //MessageBox.Show("kolom1: " + baca["kolom1"] + "kolom2: " + baca["kolom2"]);
                            String namma = (string)(baca["nama"]);
                            String alammat = (string)(baca["alamat"]);
                            String nimm = (string)(baca["nim"]);
                            String platt1 = (string)(baca["plat1"]);// konversi data dari database ke string
                            String merkk1 = (string)(baca["merk1"]);
                            String warnaa1 = (string)(baca["warna1"]);
                            String platt2 = (string)(baca["plat2"]);
                            String merkk2 = (string)(baca["merk2"]);
                            String warnaa2 = (string)(baca["warna2"]);
                            String platt3 = (string)(baca["plat3"]);
                            String merkk3 = (string)(baca["merk3"]);
                            String warnaa3 = (string)(baca["warna3"]);
                            textBox1.Text = platt1;
                            textBox3.Text = platt2;
                            textBox5.Text = platt3;
                            textBox2.Text = merkk1;
                            textBox4.Text = merkk2;
                            textBox6.Text = merkk3;
                            textBox7.Text = namma;
                            textBox8.Text = nimm;
                            textBox9.Text = alammat;
                            textBox10.Text = warnaa1;
                            textBox11.Text = warnaa2;
                            textBox12.Text = warnaa3;
                        }
                        String nama_gambar = String.Format("../kumpulan_gambar_qr_code_percobaan/{0}.png", decoded);
                        pictureBox2.Image = Image.FromFile(nama_gambar);
                        pembacaan_lama = decoded;
                        kon.Close();
                        //hasil.Text = decoded;
                        //*****************************batas fungi penampil***********************************//

                        //***************************** fungi penambah data ke data_keluar***********************************//
                        hari_ini = DateTime.Now.ToString("dd/MM/yyyy");
                        if (!tanggall.Equals(hari_ini)) //menambah column jika data keluar yang ada belum update dan ini compare string
                        {
                            kon.Open();
                           
                            String satu = "1";
                            tambah = String.Format("insert into data_keluar(tanggal,total) values( '{0}' , '{1}' )", hari_ini, satu);
                            SQLiteCommand perintah6 = new SQLiteCommand(tambah, kon);
                            perintah6.ExecuteNonQuery();

                            cari = String.Format("select max(ID) from data_keluar");

                            SQLiteCommand perintah7 = new SQLiteCommand(cari, kon);
                            perintah7.ExecuteNonQuery();
                            SQLiteDataReader baca5 = perintah7.ExecuteReader();


                            while (baca5.Read())
                            {

                                akhir = baca5.GetInt16(0); // mendapatkan data yang ada pada nilai maximum ID
                                b = akhir.ToString(); //cara mengkonversi integer ke string
                                                      //MessageBox.Show(b);
                            }


                            akhirkurang2 = akhir - 2;
                            c = akhirkurang2.ToString();
                            cari = String.Format("select * from data_keluar where ID='{0}'", c);
                            SQLiteCommand perintah8 = new SQLiteCommand(cari, kon);
                            perintah8.ExecuteNonQuery();
                            SQLiteDataReader baca6 = perintah8.ExecuteReader();

                            while (baca6.Read())
                            {
                                tanggall2 = (string)(baca6["tanggal"]);
                                totall2 = (baca6["total"]).ToString();
                                y2 = int.Parse(totall2); ///konversi dari string ke integer
                            }

                            akhirkurang1 = akhir - 1;
                            c = akhirkurang1.ToString();
                            cari = String.Format("select * from data_keluar where ID='{0}'", c);
                            SQLiteCommand perintah9 = new SQLiteCommand(cari, kon);
                            perintah9.ExecuteNonQuery();
                            SQLiteDataReader baca7 = perintah9.ExecuteReader();


                            while (baca7.Read())
                            {



                                tanggall1 = (baca7["tanggal"]).ToString();
                                totall1 = (baca7["total"]).ToString();
                                y1 = int.Parse(totall1); ///konversi dari string ke integer

                                // MessageBox.Show((string)(baca["tanggal"]) + (string)(baca["total"]));
                            }


                            c = akhir.ToString();
                            cari = String.Format("select * from data_keluar where ID='{0}'", c);
                            SQLiteCommand perintah10 = new SQLiteCommand(cari, kon);
                            perintah10.ExecuteNonQuery();
                            SQLiteDataReader baca8 = perintah10.ExecuteReader();
                           
                            while (baca8.Read())
                            {



                                tanggall = (string)(baca8["tanggal"]);
                                totall = (baca8["total"]).ToString();
                                y = int.Parse(totall); ///konversi dari string ke integer

                                // MessageBox.Show((string)(baca["tanggal"]) + (string)(baca["total"]));
                            }


                            kon.Close();
                            
                            chart1.Series["jumlah"].Points.ElementAt(0).SetValueXY(tanggall2, y2);
                            chart1.Series["jumlah"].Points.ElementAt(1).SetValueXY(tanggall1, y1);
                            chart1.Series["jumlah"].Points.ElementAt(2).SetValueXY(tanggall, y);
                        }
                        else
                        {
                            y = y + 1;
                            int y_baru = y;
                            string aw =y.ToString();
                           // MessageBox.Show(aw);
                            kon.Open();
                            update = String.Format("update data_keluar set total = '{0}' where  tanggal= '{1}' ", y, hari_ini);
                            SQLiteCommand perintah11 = new SQLiteCommand(update, kon);
                            perintah11.ExecuteNonQuery();
                            kon.Close();
                            chart1.Series["jumlah"].Points.ElementAt(2).SetValueXY(tanggall, y_baru);
                            y = y_baru;
                        }
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                timer2.Enabled = true;
                timer2.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }

        private void bersih(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            FinalFrame.Stop();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            satu_kali_start_scan = true;

            //hasil.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void hasil_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //hasil.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }
        public int akhir;
        public String totall;
        public int y;
        public String tanggall;
        public String totall1;
        public int y1;
        public String tanggall1;
        public String totall2;
        public int y2;
        public String tanggall2;
        public int akhirkurang2;
        public int akhirkurang1;
        public String cari1;
        public string c;
        public bool k = true;
        public String g;
        public String b;
        public String cari5;
        public String l;
        public String a;


        private void chart_pertamakali()
        {
            SQLiteConnection kon1;
            kon1 = new SQLiteConnection("Data Source  = data_aplikasi.db3;Version =3;");
            kon1.Open();
            cari = String.Format("select max(ID) from data_keluar");
            SQLiteCommand perintah2 = new SQLiteCommand(cari, kon1);
            perintah2.ExecuteNonQuery();

            SQLiteDataReader baca1 = perintah2.ExecuteReader();

            while (baca1.Read())
            {

                akhir = baca1.GetInt16(0); // mendapatkan data yang ada pada nilai maximum ID
                b = akhir.ToString(); //cara mengkonversi integer ke string
                //MessageBox.Show(b);
            }



            akhirkurang2 = akhir - 2;
            c = akhirkurang2.ToString();
            cari = String.Format("select * from data_keluar where ID='{0}'", c);
            SQLiteCommand perintah3 = new SQLiteCommand(cari, kon1);
            perintah3.ExecuteNonQuery();
            SQLiteDataReader baca2 = perintah3.ExecuteReader();
            while (baca2.Read())
            {



                tanggall2 = (string)(baca2["tanggal"]);
                totall2 = (baca2["total"]).ToString();
                y2 = int.Parse(totall2); ///konversi dari string ke integer

                // MessageBox.Show((string)(baca["tanggal"]) + (string)(baca["total"]));
            }


            akhirkurang1 = akhir - 1;
            c = akhirkurang1.ToString();
            cari = String.Format("select * from data_keluar where ID='{0}'", c);
            SQLiteCommand perintah4 = new SQLiteCommand(cari, kon1);
            perintah4.ExecuteNonQuery();
            SQLiteDataReader baca3 = perintah4.ExecuteReader();

            while (baca3.Read())
            {



                tanggall1 = (baca3["tanggal"]).ToString();
                totall1 = (baca3["total"]).ToString();
                y1 = int.Parse(totall1); ///konversi dari string ke integer

                // MessageBox.Show((string)(baca["tanggal"]) + (string)(baca["total"]));
            }

            c = akhir.ToString();
            cari = String.Format("select * from data_keluar where ID='{0}'", c);
            SQLiteCommand perintah5 = new SQLiteCommand(cari, kon1);
            perintah5.ExecuteNonQuery();
            SQLiteDataReader baca4 = perintah5.ExecuteReader();
            while (baca4.Read())
            {



                tanggall = (string)(baca4["tanggal"]);
                totall = (baca4["total"]).ToString();
                y = int.Parse(totall); ///konversi dari string ke integer

                // MessageBox.Show((string)(baca["tanggal"]) + (string)(baca["total"]));
            }

            kon1.Close();
            chart1.Series["jumlah"].Points.AddXY(tanggall2, y2); //menampilkan untuk pertama kalinya
            chart1.Series["jumlah"].Points.AddXY(tanggall1, y1);
            chart1.Series["jumlah"].Points.AddXY(tanggall, y);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer3.Stop();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            
            label19.Text = DateTime.Now.ToString("HH:mm"); //menampilkan tanggal dan jam secara Real time
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
        public String username;
        public String password;
        public String un;
        public String psw;
        public Boolean kunci_buka;
        public Boolean setelah_search;
        private void login_Click(object sender, EventArgs e)
        {
            SQLiteConnection kon2 = new SQLiteConnection("Data Source  = data_aplikasi.db3;Version =3;");
            kon2.Open();
            username = textBox13.Text;
            password = textBox14.Text;
            
            cari = String.Format("select * from un_and_psw where username = '{0}' and password = '{1}'", username,password);
            SQLiteCommand perintah12 = new SQLiteCommand(cari, kon2);
            perintah12.ExecuteNonQuery();
            SQLiteDataReader baca9 = perintah12.ExecuteReader();
            // MessageBox.Show(baca.Read());
            while (baca9.Read())
            {
                //MessageBox.Show("kolom1: " + baca["kolom1"] + "kolom2: " + baca["kolom2"]);
                un = (string)(baca9["username"]);
                psw = (string)(baca9["password"]);
               
            }
            if (!username.Equals(un) && !password.Equals(psw))
            {
                textBox13.Text = "maaf,coba lagi";
                textBox14.Text = "";
                kunci_buka = false;
                setelah_search = false;
            }
            else
            {
                textBox13.Text = "silahkan edit data";
                textBox14.Text = "";
                kunci_buka = true;
            }
            kon2.Close();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            kunci_buka = false;
            textBox13.Text = "anda keluar";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            setelah_search = false;
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (kunci_buka == true && setelah_search == true)
            {
                code_cari = textBox15.Text;
                nama_cari = textBox16.Text;
                nim_cari = textBox17.Text;
                alamat_cari = textBox27.Text;
                plat1_cari = textBox20.Text;
                plat2_cari = textBox23.Text;
                plat3_cari = textBox26.Text;
                merk1_cari = textBox19.Text;
                merk2_cari = textBox22.Text;
                merk3_cari = textBox25.Text;
                warna1_cari = textBox18.Text;
                warna2_cari = textBox21.Text;
                warna3_cari = textBox24.Text;
                SQLiteConnection kon4 = new SQLiteConnection("Data Source  = data_aplikasi.db3;Version =3;");
                kon4.Open();
                update = String.Format("update data_kendaraan set code = '{0}' , nama  = '{1}' , nim ='{2}' , alamat ='{3}' , plat1 = '{4}' , merk1 = '{5}' , warna1 = '{6}' , plat2 = '{7}' , merk2 = '{8}' , warna2 = '{9}' , plat3 = '{10}' , merk3 = '{11}' , warna3 = '{12}' where ID = '{13}'", code_cari, nama_cari, nim_cari, alamat_cari, plat1_cari, merk1_cari, warna1_cari, plat2_cari, merk2_cari, warna2_cari, plat3_cari, merk3_cari, warna3_cari,ID_cari_kestring);
                SQLiteCommand perintah14 = new SQLiteCommand(update, kon4);
                perintah14.ExecuteNonQuery();
                kon4.Close();

                /*textBox15.Text = code_cari;
                textBox16.Text = nama_cari;
                textBox17.Text = nim_cari;
                textBox27.Text = alamat_cari;
                textBox20.Text = plat1_cari;
                textBox23.Text = plat2_cari;
                textBox26.Text = plat3_cari;
                textBox19.Text = merk1_cari;
                textBox22.Text = merk2_cari;
                textBox25.Text = merk3_cari;
                textBox18.Text = warna1_cari;
                textBox21.Text = warna2_cari;
                textBox24.Text = warna3_cari; */
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


        public String ID_cari_kestring,code_cari, nama_cari, nim_cari, alamat_cari, plat1_cari, plat2_cari, plat3_cari;
        public String merk1_cari, merk2_cari, merk3_cari, warna1_cari, warna2_cari, warna3_cari;
        public int ID_cari;

        private void button3_Click(object sender, EventArgs e)
        {
            if(kunci_buka == true)
            {
                setelah_search = true;
                SQLiteConnection kon3 = new SQLiteConnection("Data Source  = data_aplikasi.db3;Version =3;");
                kon3.Open();
                code_cari = textBox15.Text;
                nama_cari = textBox16.Text;
                nim_cari = textBox17.Text;
                alamat_cari = textBox27.Text;
                plat1_cari = textBox20.Text;
                plat2_cari = textBox23.Text;
                plat3_cari = textBox26.Text;
                merk1_cari = textBox19.Text;
                merk2_cari = textBox22.Text;
                merk3_cari = textBox25.Text;
                warna1_cari = textBox18.Text;
                warna2_cari = textBox21.Text;
                warna3_cari = textBox24.Text;



                cari = String.Format("select * from data_kendaraan where code = '{0}' or nama  = '{1}' or nim ='{2}' or alamat ='{3}' or plat1 = '{4}' or merk1 = '{5}' or warna1 = '{6}' or plat2 = '{7}' or merk2 = '{8}' or warna2 = '{9}' or plat3 = '{10}' or merk3 = '{11}' or warna3 = '{12}' ", code_cari, nama_cari,nim_cari,alamat_cari,plat1_cari,merk1_cari, warna1_cari,plat2_cari, merk2_cari, warna2_cari,plat3_cari, merk3_cari, warna3_cari);              
                SQLiteCommand perintah13 = new SQLiteCommand(cari, kon3);
                perintah13.ExecuteNonQuery();
                SQLiteDataReader baca10 = perintah13.ExecuteReader();
                // MessageBox.Show(baca.Read());
                while (baca10.Read())
                {
                    ID_cari = baca10.GetInt16(0);
                    ID_cari_kestring = ID_cari.ToString();//mendapatkan nilai dari sebuah array di baris pada tabel di database
                   //////*************** PENTING:::::::: Cara mendapatkan data dari SQLite bisa dengan cara 
                   // baca10.GetInt16(isi no array) atau dengan baca10.getString(isi no array)
                   // atau (string)(baca10["code"])
                  

                    // string x = ID_cari.ToString();
                   // MessageBox.Show(x);
                    textBox15.Text = (string)(baca10["code"]);
                    textBox16.Text = (string)(baca10["nama"]);
                    textBox17.Text = (string)(baca10["nim"]);
                    textBox18.Text = (string)(baca10["warna1"]);
                    textBox19.Text = (string)(baca10["merk1"]);
                    textBox20.Text = (string)(baca10["plat1"]);
                    textBox21.Text = (string)(baca10["warna2"]);
                    textBox22.Text = (string)(baca10["merk2"]);
                    textBox23.Text = (string)(baca10["plat2"]);
                    textBox24.Text = (string)(baca10["warna3"]);
                    textBox25.Text = (string)(baca10["merk3"]);
                    textBox26.Text = (string)(baca10["plat3"]);
                    textBox27.Text = (string)(baca10["alamat"]);
                    
                    
                }
                kon3.Close();
            }
        }
    }
}
