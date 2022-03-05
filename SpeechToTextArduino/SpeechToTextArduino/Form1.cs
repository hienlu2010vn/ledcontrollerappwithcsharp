using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;

namespace SpeechToTextArduino
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        SpeechRecognitionEngine engine = new SpeechRecognitionEngine();
        Choices list = new Choices();
        int check;
        public Form1()
        {
            InitializeComponent();
            check = 0;
            list.Add(new string[] {
                "red on",
                "red off",
                "green on",
                "green off",
                "yellow on",
                "yellow off",
                "all on",
                "all off"
            });
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM1";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
        }
        void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text.ToString() == "red on")
            {
                _serialPort.Write("redon");
                label1.Text = "Red On";
            }
            else if (e.Result.Text.ToString() == "red off")
            {
                _serialPort.Write("redoff");
                label1.Text = "Red Off";
            }
            else if (e.Result.Text.ToString() == "green on")
            {
                _serialPort.Write("greenon");
                label1.Text = "Green On";
            }
            else if (e.Result.Text.ToString() == "green off")
            {
                _serialPort.Write("greenoff");
                label1.Text = "Green Off";
            }
            else if (e.Result.Text.ToString() == "yellow on")
            {
                _serialPort.Write("yellowon");
                label1.Text = "Yellow On";
            }
            else if (e.Result.Text.ToString() == "yellow off")
            {
                _serialPort.Write("yellowoff");
                label1.Text = "Yellow Off";
            }
            else if (e.Result.Text.ToString() == "all on")
            {
                _serialPort.Write("allon");
                label1.Text = "All On";
            }
            else if (e.Result.Text.ToString() == "all off")
            {
                _serialPort.Write("alloff");
                label1.Text = "All Off";
            }
            Thread.Sleep(200);
            label2.Text = "ok";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                Grammar gr = new Grammar(new GrammarBuilder(list));
                try
                {
                    engine.RequestRecognizerUpdate();
                    engine.LoadGrammar(gr);
                    engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(engine_SpeechRecognized);
                    engine.SetInputToDefaultAudioDevice();
                    engine.RecognizeAsync(RecognizeMode.Multiple);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { 
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            _serialPort.Write(textBox1.Text);
            label2.Text = "ok";
            label1.Text = textBox1.Text;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //_serialPort.Close();
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
