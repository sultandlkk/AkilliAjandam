using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

//AIzaSyA8IPk48jacHnidBCi54ksxOehFXEQNI6Q

namespace AkilliAjandam1
{
    public partial class Form1 : Form
    {
        
        private static readonly string apiKey = ""; // Buraya kendi API anahtarını gir

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] sehirler = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya",
                      "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir",
                      "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis",
                      "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum",
                      "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum",
                      "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
                      "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş",
                      "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale",
                      "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
                      "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde",
                      "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop",
                      "Sivas", "Şanlıurfa", "Şırnak", "Tekirdağ", "Tokat", "Trabzon",
                      "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
            comboBox1.Items.AddRange(sehirler);

            string[] universiteler = {
    "Abant İzzet Baysal Üniversitesi", "Acıbadem Mehmet Ali Aydınlar Üniversitesi",
    "Adana Alparslan Türkeş Bilim ve Teknoloji Üniversitesi", "Adıyaman Üniversitesi",
    "Afyon Kocatepe Üniversitesi", "Ağrı İbrahim Çeçen Üniversitesi", "Aksaray Üniversitesi",
    "Alanya Alaaddin Keykubat Üniversitesi", "Altınbaş Üniversitesi", "Anadolu Üniversitesi",
    "Ankara Üniversitesi", "Ankara Medipol Üniversitesi", "Ankara Müzik ve Güzel Sanatlar Üniversitesi",
    "Ankara Yıldırım Beyazıt Üniversitesi", "Ardahan Üniversitesi", "Atatürk Üniversitesi",
    "Aydın Adnan Menderes Üniversitesi", "Bahçeşehir Üniversitesi", "Balıkesir Üniversitesi",
    "Bandırma Onyedi Eylül Üniversitesi", "Başkent Üniversitesi", "Bartın Üniversitesi",
    "Beykent Üniversitesi", "Bilecik Şeyh Edebali Üniversitesi", "Bingöl Üniversitesi",
    "Bitlis Eren Üniversitesi", "Boğaziçi Üniversitesi", "Bolu Abant İzzet Baysal Üniversitesi",
    "Bursa Teknik Üniversitesi", "Bursa Uludağ Üniversitesi", "Çanakkale Onsekiz Mart Üniversitesi",
    "Çankaya Üniversitesi", "Çankırı Karatekin Üniversitesi", "Cumhuriyet Üniversitesi",
    "Çukurova Üniversitesi", "Dicle Üniversitesi", "Dokuz Eylül Üniversitesi",
    "Düzce Üniversitesi", "Ege Üniversitesi", "Erciyes Üniversitesi",
    "Erzincan Binali Yıldırım Üniversitesi", "Erzurum Teknik Üniversitesi", "Eskişehir Osmangazi Üniversitesi",
    "Fırat Üniversitesi", "Galatasaray Üniversitesi", "Gaziantep Üniversitesi",
    "Gaziosmanpaşa Üniversitesi", "Gebze Teknik Üniversitesi", "Giresun Üniversitesi",
    "Gümüşhane Üniversitesi", "Hacettepe Üniversitesi", "Hakkari Üniversitesi",
    "Harran Üniversitesi", "Hitit Üniversitesi", "Iğdır Üniversitesi",
    "İnönü Üniversitesi", "İskenderun Teknik Üniversitesi", "İstanbul Üniversitesi",
    "İstanbul Medeniyet Üniversitesi", "İstanbul Teknik Üniversitesi", "İzmir Bakırçay Üniversitesi",
    "İzmir Demokrasi Üniversitesi", "İzmir Ekonomi Üniversitesi", "İzmir Kâtip Çelebi Üniversitesi",
    "İzmir Yüksek Teknoloji Enstitüsü", "Kafkas Üniversitesi", "Kahramanmaraş Sütçü İmam Üniversitesi",
    "Karabük Üniversitesi", "Karadeniz Teknik Üniversitesi", "Karamanoğlu Mehmetbey Üniversitesi",
    "Kırıkkale Üniversitesi", "Kırklareli Üniversitesi", "Kilis 7 Aralık Üniversitesi",
    "Kocaeli Üniversitesi", "Konya Teknik Üniversitesi", "Malatya Turgut Özal Üniversitesi",
    "Manisa Celal Bayar Üniversitesi", "Marmara Üniversitesi", "Mersin Üniversitesi",
    "Mimar Sinan Güzel Sanatlar Üniversitesi", "Muğla Sıtkı Koçman Üniversitesi",
    "Mustafa Kemal Üniversitesi", "Necmettin Erbakan Üniversitesi", "Nevşehir Hacı Bektaş Veli Üniversitesi",
    "Niğde Ömer Halisdemir Üniversitesi", "Ondokuz Mayıs Üniversitesi", "Ordu Üniversitesi",
    "Osmaniye Korkut Ata Üniversitesi", "Pamukkale Üniversitesi", "Recep Tayyip Erdoğan Üniversitesi",
    "Sakarya Üniversitesi", "Samsun Üniversitesi", "Selçuk Üniversitesi",
    "Siirt Üniversitesi", "Sinop Üniversitesi", "Süleyman Demirel Üniversitesi",
    "Trakya Üniversitesi", "Türk-Alman Üniversitesi", "Uşak Üniversitesi",
    "Van Yüzüncü Yıl Üniversitesi", "Yalova Üniversitesi", "Yıldız Teknik Üniversitesi",
    "Yozgat Bozok Üniversitesi", "Zonguldak Bülent Ecevit Üniversitesi"
};
            comboBox2.Items.AddRange(universiteler);

            string[] bolumler = {
    "Bilgisayar Mühendisliği", "Yazılım Mühendisliği", "Elektrik-Elektronik Mühendisliği",
    "Makine Mühendisliği", "İnşaat Mühendisliği", "Endüstri Mühendisliği", "Mekatronik Mühendisliği",
    "Gıda Mühendisliği", "Harita Mühendisliği", "Kimya Mühendisliği", "Metalurji ve Malzeme Mühendisliği",
    "Jeoloji Mühendisliği", "Çevre Mühendisliği", "Otomotiv Mühendisliği", "Biyomedikal Mühendisliği",
    "Enerji Sistemleri Mühendisliği", "Uzay ve Havacılık Mühendisliği", "Petrol ve Doğal Gaz Mühendisliği",
    "Tıp", "Diş Hekimliği", "Eczacılık", "Hemşirelik", "Fizyoterapi ve Rehabilitasyon",
    "Beslenme ve Diyetetik", "Veterinerlik", "Sağlık Yönetimi",
    "Hukuk", "İktisat", "İşletme", "Maliye", "Bankacılık ve Finans", "Uluslararası İlişkiler",
    "Siyaset Bilimi ve Kamu Yönetimi", "Psikoloji", "Felsefe", "Sosyoloji",
    "İletişim Fakültesi", "Radyo, Televizyon ve Sinema", "Gazetecilik", "Halkla İlişkiler ve Tanıtım",
    "Mütercim-Tercümanlık", "Türk Dili ve Edebiyatı", "Tarih", "Coğrafya", "Sanat Tarihi",
    "Matematik", "Fizik", "Kimya", "Biyoloji", "Astronomi ve Uzay Bilimleri",
    "Mimarlık", "İç Mimarlık", "Peyzaj Mimarlığı", "Şehir ve Bölge Planlama",
    "Gastronomi ve Mutfak Sanatları", "Turizm ve Otel İşletmeciliği", "Rekreasyon Yönetimi",
    "İlahiyat", "İslami İlimler",
    "Güzel Sanatlar Fakültesi", "Grafik Tasarım", "Heykel", "Resim", "Müzik", "Sahne Sanatları"
};
            comboBox3.Items.AddRange(bolumler);

            string[] hobiler = {
        "Kitap okumak", "Film izlemek", "Dizi izlemek", "Müzik dinlemek", "Şarkı söylemek",
        "Dans etmek", "Resim çizmek", "Boyama yapmak", "Heykel yapmak", "Fotoğraf çekmek",
        "Tiyatro izlemek", "Senaryo yazmak", "Hikaye yazmak", "Blog yazmak", "Şiir yazmak",
        "Seyahat etmek", "Kamp yapmak", "Doğa yürüyüşleri yapmak", "Bisiklete binmek", "Koşu yapmak",
        "Spor salonuna gitmek", "Futbol oynamak", "Basketbol oynamak", "Voleybol oynamak", "Tenis oynamak",
        "Yüzme", "Dalış yapmak", "Kayak yapmak", "Yoga yapmak", "Meditasyon yapmak",
        "Yemek yapmak", "Yeni tarifler denemek", "Pasta ve tatlı yapmak", "Kahve demlemek",
        "Bahçeyle uğraşmak", "Bitki yetiştirmek", "Balık tutmak", "Araba sürmek", "Motor sürmek",
        "El işi ve örgü yapmak", "Ahşap oymacılığı", "Maket yapmak", "Koleksiyon yapmak", "Bulmaca çözmek",
        "Satranç oynamak", "Bilgisayar oyunları oynamak", "Masa oyunları oynamak", "Kod yazmak", "Elektronik projeler yapmak",
        "Astronomiyle ilgilenmek", "Dijital sanat yapmak", "Podcast dinlemek", "Yeni diller öğrenmek", "Astrolojiyle ilgilenmek"
    };
            checkedListBox1.Items.AddRange(hobiler);


           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);    // masaüstünü göstermesi için
            openFileDialog1.Filter = "JPEG (*.jpg; *jpeg; *jpe)|*.jpg; *jpeg; *jpe|PDF (*.pdf)|*.pdf|All files (*.*)|*.*";        // dosya filtrelemesi
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            foreach (string s in openFileDialog1.FileNames)     // multi select özelliği için kullanılabilir
                            {
                                // Eğer JPEG veya PNG dosyasıysa PictureBox'a yerleştir
                                if (s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png"))
                                {
                                    pictureBox1.ImageLocation = s;
                                    pictureBox1.Visible = true;  // PictureBox'ı görünür yap
                                    btnSil.Visible = true;         // Silme butonunu görünür yap
                                }
                                // PDF dosyası ise farklı bir işlem yapılabilir (örn: PDF görüntüleme)
                                else if (s.EndsWith(".pdf"))
                                {
                                    // PDF dosyasını açmak için uygun bir işlem yapılabilir
                                    MessageBox.Show("PDF dosyası seçildi: " + s);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: Dosya okunamadı!" + ex.Message);
                }
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = string.Empty;  // PictureBox içindeki resmi temizle
            pictureBox1.Visible = true;                // PictureBox'ı gizle
            btnSil.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sehir = comboBox1.SelectedItem?.ToString();
            string universite = comboBox2.SelectedItem?.ToString();
            string bolum = comboBox3.SelectedItem?.ToString();

            // Seçili hobileri al
            List<string> hobiler = checkedListBox1.CheckedItems.Cast<string>().ToList();

            // Kullanıcının boş zamanlarını belirlemek için örnek bir saat aralığı (ders programına göre düzenlenebilir)
            List<string> bosZamanlar = new List<string> { "Pazartesi 14:00-18:00", "Çarşamba 10:00-12:00", "Cuma 16:00-20:00" };

            // Google AI API'den cevap almak için metni hazırlıyoruz
            string prompt = $"Ben {sehir} şehrinde, {universite} üniversitesinde {bolum} bölümünde okuyorum. " +
                             $"Hobilerim: {string.Join(", ", hobiler)}. Ders programıma göre boş zamanlarım: {string.Join(", ", bosZamanlar)}. " +
                             "Bana boş zamanlarımda yapabileceğim uygun etkinlik önerileri sunar mısın?";

            // Google Cloud API Key (API anahtarını buraya girin)
            string apiKey = "";

            // API URL'si (Örnek, kullanılan servise göre farklılık gösterebilir)
            string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=GEMINI_API_KEY" + apiKey;

            using (HttpClient client = new HttpClient())
            {
                var requestData = new
                {
                    contents = new[]
                    {
                        new { parts = new[] { new { text = prompt } } }
                    }
                };

                string jsonRequest = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;
                        dynamic responseObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                        string aiResponse = responseObject?.candidates[0]?.content?.parts[0]?.text;

                        if (!string.IsNullOrEmpty(aiResponse))
                        {
                            List<string> etkinlikListesi = aiResponse.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Etkinlikler");

                            foreach (var etkinlik in etkinlikListesi)
                            {
                                dt.Rows.Add(etkinlik.Trim());
                            }

                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("API'den geçerli bir yanıt alınamadı.");
                        }
                    }
                    else
                    {
                        string errorMessage = response.Content.ReadAsStringAsync().Result;
                        MessageBox.Show($"API isteği başarısız oldu: {response.StatusCode} - {response.ReasonPhrase}\n{errorMessage}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
    }
}

    
    
    

    

