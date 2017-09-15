using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PictureASCII
{
    public partial class Form1 : Form
    {
        string pixels = "";
        string pixels1 = "@%#*+=-:. ";
        string pixels2 = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/" + "\\|()1{}[]?-_+~<>i!lI;:," + "\" ^`'. ";
        string pixels3 = "█▓▒░ ";
        string fileNotLoaded = "[File not loaded]";
        string fileLoadedLocal = "[File loaded from local path]";
        string fileLoadedURL = "[File loaded from URL]";
        string saved = "File saved";
        string directoryMessage = "Please make sure that you choose directory before saving a file!";
        string error404 = "URL is not valid - 404 Not Found.";
        string emptyURL = "Please, input a valid URL address!";
        string notValidURL = "URL address is not valid! Make sure that your URL address is valid!";
        string pictureFormat = "The picture must be in PNG, JPG, JPEG, GIF or BMP format!";
        int state = 0;
        Bitmap myBitmap = new Bitmap(1, 1);
        Image img;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                myBitmap = new Bitmap(openFileDialog.FileName);
                //img = Image.FromFile(openFileDialog.FileName);
                img = myBitmap;
                buttonConvert.Enabled = true;
                buttonDeleteLocal.Enabled = true;
                labelFileLoaded.Text = fileLoadedLocal;
                state = 1;
                labelFileLoaded.ForeColor = Color.LimeGreen;
                textBoxLocal.Text = openFileDialog.FileName;
                buttonURL.Enabled = false;
                textBoxURL.Enabled = false;
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            int size = 0;
            Int32.TryParse(textBoxSize.Text, out size);

            int sizeW = size * 100;
            int sizeH = sizeW;

            //if (myBitmap.Size.Width > 80)
            //{
                int width = (int)(myBitmap.Width - (myBitmap.Width * ((100 - (double)(sizeW / myBitmap.Width)) / 100)));
                int height = (int)(myBitmap.Height - (myBitmap.Height * ((100 - (double)(sizeH / myBitmap.Width)) / 100)));
                img = Resize(img, width, height);
            //}

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(saved);
            }
            else
            {
                MessageBox.Show(directoryMessage);
                return;
            }

            double index = 0;
            char pixel;
            string filePath = saveFileDialog.FileName;//Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ASCIIArt.txt";
            Debug.WriteLine(filePath);
            TextWriter file = new StreamWriter(filePath);
            double brightness = 0;
            Color color;
            //Bitmap myBitmap = new Bitmap(picturePicture.Image);
            //textASCII.Text = filePath;
            
            for (int i = 0; i < myBitmap.Height; i++)
            {
                for (int j = 0; j < myBitmap.Width; j++)
                {
                    color = myBitmap.GetPixel(j, i);
                    brightness = Brightness(color);
                    index = brightness / 255 * (pixels.Length - 1);
                    //index = brightness / 255 * (pixels1.Length - 1);
                    //index = brightness / 255 * (pixels2.Length - 1);
                    //index = brightness / 255 * (pixels3.Length - 1);
                    pixel = pixels[(int)Math.Round(index)];
                    //pixel = pixels1[(int)Math.Round(index)];
                    //pixel = pixels2[(int)Math.Round(index)];
                    //pixel = pixels3[(int)Math.Round(index)];

                    file.Write(pixel);
                    file.Write(pixel);
                }
                file.WriteLine();
            }

            file.Close();
        }

        private double Brightness(Color c)
        {
            return Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }

        Image Resize(Image image, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.DrawImage(image, 0, 0, width, height);
            graphic.Dispose();

            myBitmap = bmp;
            return myBitmap;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                pixels = "@%#*+=-:. ";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                pixels = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/" + "\\|()1{}[]?-_+~<>i!lI;:," + "\" ^`'. ";
            }
            else
            {
                pixels = "█▓▒░ ";
            }
        }

        private void textBoxSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;

            if (!Char.IsDigit(character) && character != 8 && character != 46)
            {
                e.Handled = true;
            }
        }

        private void buttonURL_Click(object sender, EventArgs e)
        {
            Uri uriResult;

            if(string.IsNullOrWhiteSpace(textBoxURL.Text))
            {
                MessageBox.Show(emptyURL);
                textBoxURL.Text = "";
                return;
            }
            else if(!(Uri.TryCreate(textBoxURL.Text, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
            {
                MessageBox.Show(notValidURL);
                return;
            }

            string URL = textBoxURL.Text;

            if(URL.Contains(".png") == true ||
                URL.Contains(".jpg") == true ||
                URL.Contains(".jpeg") == true ||
                URL.Contains(".gif") == true ||
                URL.Contains(".bmp") == true)/*textBoxURL.Text.Substring(textBoxURL.TextLength - 4, 4) == ".png" || 
                textBoxURL.Text.Substring(textBoxURL.TextLength - 4, 4) == ".jpg" ||
                textBoxURL.Text.Substring(textBoxURL.TextLength - 5, 5) == ".jpeg" ||
                textBoxURL.Text.Substring(textBoxURL.TextLength - 4, 4) == ".gif" ||
                textBoxURL.Text.Substring(textBoxURL.TextLength - 4, 4) == ".bmp"*/
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textBoxURL.Text);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show(error404);
                        response.Close();
                        return;
                    }

                    var stream = response.GetResponseStream();

                    myBitmap = new Bitmap(stream);
                    img = myBitmap;

                    response.Close();

                    labelFileLoaded.Text = fileLoadedURL;
                    state = 2;
                    labelFileLoaded.ForeColor = Color.LimeGreen;
                    buttonDeleteURL.Enabled = true;
                    buttonConvert.Enabled = true;
                }
                catch(WebException ex)
                {
                    MessageBox.Show("Error: " + ex.Status);
                    return;
                }
            }
            else
            {
                MessageBox.Show(pictureFormat);
                return;
            }
        }

        private void buttonDeleteLocal_Click(object sender, EventArgs e)
        {
            myBitmap.Dispose();
            textBoxLocal.Text = "";
            textBoxURL.Enabled = true;
            labelFileLoaded.Text = fileNotLoaded;
            state = 0;
            labelFileLoaded.ForeColor = Color.Red;
            buttonConvert.Enabled = false;
            buttonURL.Enabled = true;
            buttonDeleteLocal.Enabled = false;
        }

        private void buttonDeleteURL_Click(object sender, EventArgs e)
        {
            myBitmap.Dispose();
            textBoxURL.Text = "";
            textBoxURL.Enabled = true;
            labelFileLoaded.Text = fileNotLoaded;
            state = 0;
            labelFileLoaded.ForeColor = Color.Red;
            buttonConvert.Enabled = false;
            buttonLoad.Enabled = true;
            buttonDeleteURL.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int language = comboBox2.SelectedIndex;

            switch (language)
            {
                case 0:
                    fileNotLoaded = "[File not loaded]";
                    fileLoadedLocal = "[File loaded from local path]";
                    fileLoadedURL = "[File loaded from URL]";
                    saved = "File saved.";
                    directoryMessage = "Please make sure that you choose directory before saving a file!";
                    error404 = "URL is not valid - 404 Not Found.";
                    emptyURL = "Please, input a valid URL address!";
                    notValidURL = "URL address is not valid! Make sure that your URL address is valid!";
                    pictureFormat = "The picture must be in PNG, JPG, JPEG, GIF or BMP format!";

                    if (state == 0)
                    {
                        labelFileLoaded.Text = fileNotLoaded;
                    }
                    else if(state == 1)
                    {
                        labelFileLoaded.Text = fileLoadedLocal;
                    }
                    else
                    {
                        labelFileLoaded.Text = fileLoadedURL;
                    }

                    buttonLoad.Text = "Load the local picture";
                    buttonURL.Text = "Load picture from URL";
                    buttonLoad.Size = new Size(148, 23);
                    buttonLoad.Location = new Point(430, 9);
                    textBoxLocal.Size = new Size(412, 20);
                    buttonURL.Size = new Size(148, 23);
                    buttonURL.Location = new Point(430, 34);
                    textBoxURL.Size = new Size(412, 20);
                    labelPixels.Text = "Pixels:";
                    comboBox1.Size = new Size(540, 21);
                    comboBox1.Location = new Point(62, 80);
                    labelSize.Text = "Size (depends on your resolution screen or font size): ";
                    textBoxSize.Size = new Size(271, 20);
                    textBoxSize.Location = new Point(331, 107);
                    buttonConvert.Text = "Convert to ASCII Art";
                    labelMadeBy.Text = "Application made by Kamil Utratny";
                    labelMadeBy.Location = new Point(402, 165);
                    break;
                case 1:
                    fileNotLoaded = "[Datei nicht geladen]";
                    fileLoadedLocal = "[Datei aus dem lokalen Pfad geladen]";
                    fileLoadedURL = "[Datei aus URL geladen]";
                    saved = "Datei gespeichert.";
                    directoryMessage = "Bitte stellen Sie sicher, dass Sie das Verzeichnis vor dem Speichern einer Datei auswählen!";
                    error404 = "URL ist nicht gültig - 404 nicht gefunden.";
                    emptyURL = "Bitte geben Sie eine gültige URL-Adresse ein!";
                    notValidURL = "URL-Adresse ist nicht gültig! Stellen Sie sicher, dass Ihre URL-Adresse gültig ist!";
                    pictureFormat = "Das Bild muss im PNG-, JPG-, JPEG-, GIF- oder BMP-Format vorliegen!";

                    if (state == 0)
                    {
                        labelFileLoaded.Text = fileNotLoaded;
                    }
                    else if (state == 1)
                    {
                        labelFileLoaded.Text = fileLoadedLocal;
                    }
                    else
                    {
                        labelFileLoaded.Text = fileLoadedURL;
                    }

                    buttonLoad.Text = "Laden Sie das lokale Bild";
                    buttonURL.Text = "Bild aus URL laden";
                    buttonLoad.Size = new Size(159, 23);
                    buttonLoad.Location = new Point(419, 9);
                    textBoxLocal.Size = new Size(401, 20);
                    buttonURL.Size = new Size(159, 23);
                    buttonURL.Location = new Point(419, 34);
                    textBoxURL.Size = new Size(401, 20);
                    labelPixels.Text = "Pixel:";
                    comboBox1.Size = new Size(540, 21);
                    comboBox1.Location = new Point(62, 80);
                    labelSize.Text = "Größe (abhängig von Ihrem Auflösungsbildschirm oder Schriftgröße): ";
                    textBoxSize.Size = new Size(187, 20);
                    textBoxSize.Location = new Point(415, 107);
                    buttonConvert.Text = "Umwandlung in ASCII-Kunst";
                    labelMadeBy.Text = "Anwendung von Kamil Utratny";
                    labelMadeBy.Location = new Point(425, 165);
                    break;
                case 2:
                    fileNotLoaded = "[Archivo no cargado]";
                    fileLoadedLocal = "[Archivo cargado desde la ruta local]";
                    fileLoadedURL = "[Archivo cargado desde la URL]";
                    saved = "Archivo guardado.";
                    directoryMessage = "Por favor, asegúrese de elegir el directorio antes de guardar un archivo!";
                    error404 = "La URL no es válida - 404 no encontrada.";
                    emptyURL = "Por favor, ingrese una dirección URL válida!";
                    notValidURL = "La dirección URL no es válida! Asegúrese de que su dirección URL es válida!";
                    pictureFormat = "¡La imagen debe estar en formato PNG, JPG, JPEG, GIF o BMP!";

                    if (state == 0)
                    {
                        labelFileLoaded.Text = fileNotLoaded;
                    }
                    else if (state == 1)
                    {
                        labelFileLoaded.Text = fileLoadedLocal;
                    }
                    else
                    {
                        labelFileLoaded.Text = fileLoadedURL;
                    }

                    buttonLoad.Text = "Cargar la imagen local";
                    buttonURL.Text = "Cargar imagen desde la URL";
                    buttonLoad.Size = new Size(177, 23);
                    buttonLoad.Location = new Point(401, 9);
                    textBoxLocal.Size = new Size(383, 20);
                    buttonURL.Size = new Size(177, 23);
                    buttonURL.Location = new Point(401, 34);
                    textBoxURL.Size = new Size(383, 20);
                    labelPixels.Text = "Pixels:";
                    comboBox1.Size = new Size(540, 21);
                    comboBox1.Location = new Point(62, 80);
                    labelSize.Text = "Tamaño (depende de la resolución de la pantalla o el tamaño de la fuente):";
                    textBoxSize.Size = new Size(146, 20);
                    textBoxSize.Location = new Point(456, 107);
                    buttonConvert.Text = "Convertir a arte ASCII";
                    labelMadeBy.Text = "Aplicación realizada por Kamil Utratny";
                    labelMadeBy.Location = new Point(380, 165);
                    break;
                case 3:
                    fileNotLoaded = "[Fichier non chargé]";
                    fileLoadedLocal = "[Fichier chargé à partir du chemin local]";
                    fileLoadedURL = "[Fichier chargé à partir de l'URL]";
                    saved = "Fichier enregistré.";
                    directoryMessage = "Assurez-vous que vous choisissez le répertoire avant de sauvegarder un fichier!";
                    error404 = "L'URL n'est pas valide - 404 Not Found.";
                    emptyURL = "Veuillez entrer une adresse URL valide!";
                    notValidURL = "L'adresse URL n'est pas valide! Assurez-vous que votre adresse URL est valide!";
                    pictureFormat = "L'image doit être en format PNG, JPG, JPEG, GIF ou BMP";

                    if (state == 0)
                    {
                        labelFileLoaded.Text = fileNotLoaded;
                    }
                    else if (state == 1)
                    {
                        labelFileLoaded.Text = fileLoadedLocal;
                    }
                    else
                    {
                        labelFileLoaded.Text = fileLoadedURL;
                    }

                    buttonLoad.Text = "Charger l'image locale";
                    buttonURL.Text = "Charger l'image de l'URL";
                    buttonLoad.Size = new Size(159, 23);
                    buttonLoad.Location = new Point(419, 9);
                    textBoxLocal.Size = new Size(401, 20);
                    buttonURL.Size = new Size(159, 23);
                    buttonURL.Location = new Point(419, 34);
                    textBoxURL.Size = new Size(401, 20);
                    labelPixels.Text = "Pixels:";
                    comboBox1.Size = new Size(540, 21);
                    comboBox1.Location = new Point(62, 80);
                    labelSize.Text = "Taille (dépend de votre écran de résolution ou de la taille de la police):";
                    textBoxSize.Size = new Size(168, 20);
                    textBoxSize.Location = new Point(434, 107);
                    buttonConvert.Text = "Convertir en ASCII Art";
                    labelMadeBy.Text = "Application faite par Kamil Utratny";
                    labelMadeBy.Location = new Point(402, 165);
                    break;
                case 4:
                    fileNotLoaded = "[File non caricato]";
                    fileLoadedLocal = "[File caricato da percorso locale]";
                    fileLoadedURL = "[File caricato da URL]";
                    saved = "File salvato.";
                    directoryMessage = "Assicurarsi di scegliere la directory prima di salvare un file!";
                    error404 = "L'URL non è valido - 404 non trovato.";
                    emptyURL = "Inserisci un indirizzo URL valido!";
                    notValidURL = "L'indirizzo URL non è valido! Assicurati che l'indirizzo URL sia valido!";
                    pictureFormat = "L'immagine deve essere in formato PNG, JPG, JPEG, GIF o BMP!";

                    if (state == 0)
                    {
                        labelFileLoaded.Text = fileNotLoaded;
                    }
                    else if (state == 1)
                    {
                        labelFileLoaded.Text = fileLoadedLocal;
                    }
                    else
                    {
                        labelFileLoaded.Text = fileLoadedURL;
                    }

                    buttonLoad.Text = "Carica l'immagine locale";
                    buttonURL.Text = "Carica immagine da URL";
                    buttonLoad.Size = new Size(148, 23);
                    buttonLoad.Location = new Point(430, 9);
                    textBoxLocal.Size = new Size(412, 20);
                    buttonURL.Size = new Size(148, 23);
                    buttonURL.Location = new Point(430, 34);
                    textBoxURL.Size = new Size(412, 20);
                    labelPixels.Text = "Pixel:";
                    comboBox1.Size = new Size(540, 21);
                    comboBox1.Location = new Point(62, 80);
                    labelSize.Text = "Dimensione (dipende dalla risoluzione o dalla dimensione del carattere):";
                    textBoxSize.Size = new Size(168, 20);
                    textBoxSize.Location = new Point(434, 107);
                    buttonConvert.Text = "Converti in ASCII Art";
                    labelMadeBy.Text = "Applicazione eseguita da Kamil Utratny";
                    labelMadeBy.Location = new Point(374, 165);
                    break;
                case 5:
                    fileNotLoaded = "[Plik nie jest załadowany]";
                    fileLoadedLocal = "[Plik załadowany z lokalnej ścieżki]";
                    fileLoadedURL = "[Plik załadowany z URL]";
                    saved = "Plik zapisano.";
                    directoryMessage = "Proszę, upewnij się, że podałeś/aś ścieżkę przed zapisaniem pliku!";
                    error404 = "URL jest nieprawidłowy - 404 Not Found.";
                    emptyURL = "Proszę, podaj poprawny adres URL!";
                    notValidURL = "Adres URL jest niepoprawny! Upewnij się, że podany adres URL jest poprawny!";
                    pictureFormat = "Zdjęcie musi być formatu PNG, JPG, JPEG, GIF lub BMP!";

                    if (state == 0)
                    {
                        labelFileLoaded.Text = fileNotLoaded;
                    }
                    else if (state == 1)
                    {
                        labelFileLoaded.Text = fileLoadedLocal;
                    }
                    else
                    {
                        labelFileLoaded.Text = fileLoadedURL;
                    }

                    buttonLoad.Text = "Załaduj zdjęcie lokalne";
                    buttonURL.Text = "Załaduj zdjęcie z URL";
                    buttonLoad.Size = new Size(148, 23);
                    buttonLoad.Location = new Point(430, 9);
                    textBoxLocal.Size = new Size(412, 20);
                    buttonURL.Size = new Size(148, 23);
                    buttonURL.Location = new Point(430, 34);
                    textBoxURL.Size = new Size(412, 20);
                    labelPixels.Text = "Piksele:";
                    comboBox1.Size = new Size(532, 21);
                    comboBox1.Location = new Point(70, 80);
                    labelSize.Text = "Rozmiar (wartość zależna od rozdzielczości ekranu lub wielkości czcionki):";
                    textBoxSize.Size = new Size(150, 20);
                    textBoxSize.Location = new Point(452, 107);
                    buttonConvert.Text = "Konwertuj do ASCII Art";
                    labelMadeBy.Text = "Aplikacja napisana przez Kamil Utratny";
                    labelMadeBy.Location = new Point(375, 165);
                    break;
                case 6:
                    fileNotLoaded = "[Arquivo não carregado]";
                    fileLoadedLocal = "[Arquivo carregado do caminho local]";
                    fileLoadedURL = "[Arquivo carregado do URL]";
                    saved = "Arquivo salvo";
                    directoryMessage = "Certifique-se de escolher o diretório antes de salvar um arquivo!";
                    error404 = "URL não é válido - 404 Não encontrado.";
                    emptyURL = "Por favor, insira um endereço de URL válido!";
                    notValidURL = "O endereço de URL não é válido! Certifique-se de que seu endereço de URL seja válido!";
                    pictureFormat = "A imagem deve estar em formato PNG, JPG, JPEG, GIF ou BMP";

                    if (state == 0)
                    {
                        labelFileLoaded.Text = fileNotLoaded;
                    }
                    else if (state == 1)
                    {
                        labelFileLoaded.Text = fileLoadedLocal;
                    }
                    else
                    {
                        labelFileLoaded.Text = fileLoadedURL;
                    }

                    buttonLoad.Text = "Carregar a imagem local";
                    buttonURL.Text = "Carregar imagem a partir do URL";
                    buttonLoad.Size = new Size(200, 23);
                    buttonLoad.Location = new Point(378, 9);
                    textBoxLocal.Size = new Size(360, 20);
                    buttonURL.Size = new Size(200, 23);
                    buttonURL.Location = new Point(378, 34);
                    textBoxURL.Size = new Size(360, 20);
                    labelPixels.Text = "Pixels:";
                    comboBox1.Size = new Size(540, 21);
                    comboBox1.Location = new Point(62, 80);
                    labelSize.Text = "Tamanho (depende da tela de resolução ou do tamanho da fonte):";
                    textBoxSize.Size = new Size(198, 20);
                    textBoxSize.Location = new Point(404, 107);
                    buttonConvert.Text = "Convert to ASCII Art";
                    labelMadeBy.Text = "Aplicação feita por Kamil Utratny";
                    labelMadeBy.Location = new Point(409, 165);
                    break;
            }
        }
    }
}
