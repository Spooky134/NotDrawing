//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text.Json;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Xml.Serialization;


//namespace NotDrawing.Controllers
//{
//    public class Controller// : IController
//    {
//        public static Controller peopleController;
//        private static Controller instance;
//        private List<UIElementCollection> data;

//        private Controller()
//        {
//            data = new List<UIElementCollection>();
//        }
//        public static Controller GetInstance()
//        {
//            if (instance == null)
//            {
//                instance = new Controller();
//            }
//            return instance;
//        }

//        public async void ReadAsync(string path)
//        {
//            data.Clear();
//            try
//            {
//                using (FileStream fs = new(path, FileMode.OpenOrCreate))
//                {
//                    data.Add(await JsonSerializer.DeserializeAsync<UIElementCollection>(fs));

//                    //while ((line = fs.) != null)
//                    //{

//                    //}
//                    //sr.Close();
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//        public async void WriteAsync(string path)
//        {
//            try
//            {
//                using (FileStream fs = new(path, FileMode.OpenOrCreate))
//                {
//                    for (int i = 0; i < data.Count; i++)
//                        await
//                                JsonSerializer.SerializeAsync<string>(fs, data[i]);
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public void Update(string item)
//        {
//        }
//        public IEnumerable<UIElementCollection> GetAll()
//        {
//            return data;
//        }
//    }
//}
