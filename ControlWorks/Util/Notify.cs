using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ControlWorks
{
    [Serializable]
    public class Notify : INotifyPropertyChanged
    {
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public T DuplicarObjeto<T>()
        {
            try
            {
                using (Stream objectStream = new MemoryStream())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(objectStream, this);
                    _ = objectStream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(objectStream);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
