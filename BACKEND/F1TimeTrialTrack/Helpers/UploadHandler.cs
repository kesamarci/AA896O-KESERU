namespace F1TimeTrialTrack.Helpers
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            //extension check
            List<string> valide = new List<string>() { ".jpg",".png",".gif",".jpeg"};
            var extension = Path.GetExtension(file.FileName);
            if (!valide.Contains(extension))
            {
                return $"Fájlformátum nem megfelelő!!({string.Join(',', valide)})";
            }

            //size check
            if (file.Length >10* 1024 * 1024)
            {
                return "Fájl mérete túl nagy!(nagyobb mint 10Mb)";
            }
            string fileName = Guid.NewGuid().ToString() + extension;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }
    }
}
