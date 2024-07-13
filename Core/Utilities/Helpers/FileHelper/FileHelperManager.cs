using System;
using Core.Utilities.Helpers.GuidHelperr;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http; 


namespace Core.Utilities.Helpers.FileHelper
{
    // Projeme yükleyeceğim dosyalarla ilgili yükleme,silme,güncelleme işlemlerini bu classımda yapıyorum.
    //İşlemin nasıl gerçekleştiğini anlamak için yazdığım yorum satırlarını okumaya En alttaki *Upload* metodunundan başlayabilirsiniz.
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)//Burada ki string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı 
        {
            if (File.Exists(filePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }
        //IFormFile : Dosyanın uzantısını (bu dosya pdf mi text mi image mı vb) dosyanın boyutunu, dosyanın ismini almamıza yarar.
        public string Update(IFormFile file, string filePath, string root)//Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        {
            if (File.Exists(filePath))// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)//file.Length=>Dosya uzunluğunu bayt olarak alır. burada Dosya gönderil mi gönderilmemiş diye test işlemi yapıldı.
            {
                if (!Directory.Exists(root))//Directory=>System.IO'nın bir class'ı. burada ki işlem tam olarak şu. Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte
                {                           //CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* böyle bir şey gönderilidğini görürsünüz. PathConstants clası içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
                                            //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);//Path.GetExtension(file.FileName)=>> Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
                string guid = GuidHelper.CreateGuid();//Core.Utilities.Helpers.GuidHelper klasürünün içinde ki GuidManager klasörüne giderseniz burada satırda ne yaptığımızı anlayacaksınız
                string filePath = ($"{guid}{extension}");//Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum. Mesela metin dosyası ise .txt gibi bu projemizde resim yükyeceğimiz için .jpg olacak uzantılar 
                // guid + extension  =  ($"{guid}{extension}")   //Dolar işareti stringleri toplamaya yarar

                using (FileStream fileStream = File.Create(root + filePath))//Burada en başta FileStrem class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.
                {  //Üstteki satırda benim adresim oluşacak şöyle düşün root = Upload/Images   filePath= random üğretilecek             filestream = Upload/Images/filePath 
                    file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
                    fileStream.Flush();//Flush metodu, FileStream içinde tutulan verileri arabellekte (buffer) bekletmeden doğrudan diske yazar. Bu, verilerin diske yazıldığından emin olmanızı sağlar.
                    return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                }
                //Özetle, FileStream sınıfı, dosya okuma ve yazma işlemleri için kullanılan temel bir sınıftır.
                //Yukarıdaki kod parçasında, FileStream sınıfı bir dosya oluşturmak ve IFormFile nesnesinin içeriğini bu dosyaya kopyalamak için kullanılıyor.

            }
            return null;
        }
    }
}
