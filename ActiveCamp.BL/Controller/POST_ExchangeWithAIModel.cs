using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    public class POST_ExchangeWithAIModel
    {

        public POST_ExchangeWithAIModel() { }

        public async Task<HikingInfo> GetInfoAboutSuitableHkings(string Data)
        {
            // URL сервера Flask
            string url = "http://127.0.0.1:5000/predict";

            // Данные для отправки (массив признаков)":
            var json = "{\"features\": //Данные для отправки, массив для обработки// }";

            string result = "";

            // Создаем HttpClient для отправки запроса
            using (HttpClient client = new HttpClient())
            {
                // Настройка содержимого запроса
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Отправка POST-запроса
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Чтение ответа
                result = await response.Content.ReadAsStringAsync();
            }

            HikingInfo info = new HikingInfo(result);

            return info;
        }

    }

    public class HikingInfo : INotifyPropertyChanged, IEditableObject
    {
        private string _info;
        public string Info 
        { 
            get
            {
                return this._info;
            }
            set
            {
                if (this._info != value)
                {
                    this._info = value;
                    NotifyPropertyChanged("Info");
                }
            }
        }

        public HikingInfo(string Info ) 
        {
            this._info = Info;            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private HikingInfo temp_Record = null;
        private bool m_Editing = false;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as HikingInfo;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _info = temp_Record.Info;
                m_Editing = false;
            }
        }
        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }

    }

}