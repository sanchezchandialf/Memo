using System.Security.Cryptography.X509Certificates;

namespace Memo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Palabra
        {
            public string Descripcion { get; set; }

            public Palabra(string descripcion)
            {
                this.Descripcion = descripcion;
            }

            public override string ToString()
            {
                return $"{this.Descripcion}\n";
            }
        }

        public void MostrarEnBotones()
        {
            // Implementación futura
        }

        private void Tablero_Paint(object sender, PaintEventArgs e)
        {
            // Implementación futura
        }

        private void PalabrasEncontradas_TextChanged(object sender, EventArgs e)
        {
            // Implementación futura
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Implementación futura
        }

        private void Cargador_Click(object sender, EventArgs e)
        {
            Palabra[] palabras = new Palabra[10];
            palabras[0] = new Palabra("Hola");
            palabras[1] = new Palabra("Adios");
            palabras[2] = new Palabra("Casa");
            palabras[3] = new Palabra("Perro");
            palabras[4] = new Palabra("Gato");
            palabras[5] = new Palabra("Conejo");
            palabras[6] = new Palabra("Vaca");
            palabras[7] = new Palabra("Castor");
            palabras[8] = new Palabra("Silla");
            palabras[9] = new Palabra("Loro");

            foreach (Palabra palabra in palabras)
            {
                PalabrasEncontradas.Text += palabra.ToString();
            }
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktopPath, "ejemplo.txt");
            FileInfo file = new FileInfo(path); 
            FileStream fs= file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (StreamWriter sw = new StreamWriter(fs)) {
                foreach(Palabra palabra in palabras)
                { sw.WriteLine(palabra.ToString()); }
               
            }
            MessageBox.Show("Archivo creado");

            Button[] buttons = new Button[20];
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;
            buttons[9] = button10;
            buttons[10] = button11;
            buttons[11] = button12;
            buttons[12] = button13;
            buttons[13] = button14;
            buttons[14] = button15;
            buttons[15] = button16;
            buttons[16] = button17;
            buttons[17] = button18;
            buttons[18] = button19;
            buttons[19] = button20;

            int[] wordCount = new int[palabras.Length]; // Arreglo que cuenta las palabras que se repiten
            Random r2 = new Random();

            for (int i = 0; i < buttons.Length; i++)
            {
                bool assigned = false; // Creo un booleano para tratar la asignación
                while (!assigned) // Mientras ese booleano esté negado (!), es decir, que sea true
                {
                    int y = r2.Next(0, palabras.Length);
                    if (wordCount[y] < 2)
                    {
                        buttons[i].Text = palabras[y].Descripcion;
                        buttons[i].ForeColor = buttons[i].BackColor; // Inicialmente, el texto del botón es invisible
                        wordCount[y]++;
                        assigned = true;
                    }
                }
                buttons[i].Click += Button_Click;
            }
            MessageBox.Show("El juego puede comenzar , presione el boton de iniciar ");
        }
        private List<Button> selectedButtons = new List<Button>();

        private int pairsFound = 0;

        private int contador = 0;

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.ForeColor = Color.Black; // Mostrar el texto de la carta al hacer clic

                selectedButtons.Add(clickedButton);

                if (selectedButtons.Count == 2)
                {
                    if (selectedButtons[0].Text == selectedButtons[1].Text)
                    {
                        // Se encontró un par
                        pairsFound++;
                        contador++;
                        PalabrasDescubiertas.Text = "Palabras descubiertas: "+contador;
                        if (pairsFound == 10) // Cambia el número 10 por el número total de pares en tu juego
                        {
                            MessageBox.Show("¡Has encontrado todos los pares! ¡Ganaste!");
                            // Aquí puedes reiniciar el juego si lo deseas
                        }
                    }
                    else
                    {
                        // Ocultar las cartas después de un tiempo
                        Thread.Sleep(1000); // Esperar un segundo
                        foreach (Button button in selectedButtons)
                        {
                            button.ForeColor = button.BackColor; // Ocultar el texto de la carta
                        }
                    }
                    selectedButtons.Clear(); // Limpiar las cartas seleccionadas
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Disparador_Click(object sender, EventArgs e)
        {
            MessageBox.Show("el juego inicio");

        }

        private void PalabrasDescubiertas_Click(object sender, EventArgs e)
        {
           
        }
    }
}
