using System.Runtime.InteropServices;

namespace LFSStrobeTKbyAnton
{
    public partial class Form1 : Form
    {
        public const int KEYEVENTF_EXTENDEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 2;
        private Stream strm;
        private StreamWriter writer;
        private StreamReader reader;
        private int pos = 0;
        private int time;
        private string c;
        private string hhh;
        private Random rand = new Random();
        private char r;
        private bool cos = false;

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern byte VkKeyScan(char ch);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(int keyCode);

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
       
        public Form1()

        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private static byte BreakCode(char ch)
        {
            return ch switch
            {
                'A' => 158,
                'B' => 176,
                'C' => 174,
                'D' => 160,
                'E' => 146,
                'F' => 161,
                'G' => 162,
                'H' => 163,
                'I' => 151,
                'J' => 164,
                'K' => 165,
                'L' => 166,
                'M' => 178,
                'N' => 177,
                'O' => 152,
                'P' => 153,
                'Q' => 144,
                'R' => 147,
                'S' => 159,
                'T' => 148,
                'U' => 150,
                'V' => 175,
                'W' => 145,
                'X' => 173,
                'Y' => 149,
                'Z' => 172,
                '0' => 139,
                '1' => 130,
                '2' => 131,
                '3' => 132,
                '4' => 133,
                '5' => 134,
                '6' => 135,
                '7' => 136,
                '8' => 137,
                '9' => 138,
                _ => 0,
            };
        }

        private static new void KeyPress(char ch)
        {
            if (ch == (char)Keys.Back) return;

            byte key = VkKeyScan(ch);
            keybd_event(key, 0, 0, 0); // Press the key
            keybd_event(key, 0, KEYEVENTF_KEYUP, 0); // Release the key

        }

        private static new void KeyDown(char ch)
        {
            if (ch == (char)Keys.Back) return; // Skip if the character is Backspace

            byte key = VkKeyScan(ch); // Get the virtual key code
            keybd_event(key, 0, 0, 0); // Press the key
            
        }

        private static new void KeyUp(char ch)
        {
            keybd_event(VkKeyScan(ch), BreakCode(ch), 2, 0);
        }
        private void TurnOff()
        {
            pos = 0;
            KeyUp(r);
            KeyUp('B');
            KeyPress('0');

            label2.Text = "Stopped";
            label1.Text = "Position: " + pos;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            KeyUp(r);

            bool isChatOpen = ((ushort)GetKeyState((int)Keys.T) & 0x8000) != 0;
            if (isChatOpen)
            {
                timer1.Stop();
                TurnOff();
                label2.Text = "Chat opened, script stopped. Press Start to run script.";
                return; 
            }
            

            bool flag = ((ushort)GetKeyState(0x6B) & 0xFFFF) != 0;
            if (!flag && cos)
            {
                KeyUp(r);
                KeyUp('B');
                KeyPress('0');
                cos = false;
            }
            if (!flag)
            {
                label2.Text = "Stopped, + to start";
                pos = 0;
                label1.Text = "Position: " + pos;
                timer1.Interval = 800;
                return;
            }
            cos = true;
            label2.Text = "Running";

            if (checkBox2.Checked)
            {
                KeyDown('B');
            }

            if (checkBox1.Checked)
            {
                if (rand.NextDouble() > 0.5)
                {
                    r = '0';
                }
                else if (rand.NextDouble() > 0.7)
                {
                    r = '7';
                }
                else if (rand.NextDouble() > 0.7)
                {
                    r = '8';
                }
                else
                {
                    r = textBox1.Text[0];
                }
                KeyDown(r);
                timer1.Interval = (int)(rand.NextDouble() * 130.0 + 20.0);
                return;
            }

            if (dataGridView1.RowCount < 2 || !Check())
            {
                TurnOff();
                MessageBox.Show("RowCount insufficient or data wrong...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (pos >= dataGridView1.RowCount - 1)
            {
                pos = 0;
            }

            label1.Text = "Position: " + pos;
            c = dataGridView1.Rows[pos].Cells[0].Value?.ToString() ?? "";
            hhh = dataGridView1.Rows[pos].Cells[1].Value?.ToString() ?? "";

            r = c[0];
            KeyDown(r);
            int.TryParse(hhh, out time);

            timer1.Interval = time;
            pos++;
        }

        private bool Check()
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (string.IsNullOrEmpty((string)dataGridView1.Rows[i].Cells[0].Value))
                {
                    return false;
                }

                if (string.IsNullOrEmpty((string)dataGridView1.Rows[i].Cells[1].Value))
                {
                    return false;
                }

                if (!int.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out var _))
                {
                    return false;
                }
            }
            return true;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 2)
            {
                label1.Text = "Put smth!";
            }
            else
            {
                label1.Text = "Amount:" + dataGridView1.RowCount;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = ".\\",
                Filter = "All files (*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    strm = openFileDialog.OpenFile();
                    reader = new StreamReader(strm);
                }
                catch (Exception ex)
                {
                    string text = ex.Message + "\n\nCannot open file" + openFileDialog.FileName;
                    MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                dataGridView1.Rows.Clear();
                int num;
                try
                {
                    num = (int)Convert.ToDecimal(reader.ReadLine());
                }
                catch (Exception)
                {
                    MessageBox.Show("File is corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                for (int i = 0; i < num; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader.ReadLine();
                    dataGridView1.Rows[i].Cells[1].Value = reader.ReadLine();
                }

                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 2);
                reader.Close();
                strm.Close();

//                MessageBox.Show("File Loaded!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = ".\\",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = false
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    strm = saveFileDialog.OpenFile();
                    writer = new StreamWriter(strm);
                }
                catch (Exception ex)
                {
                    string text = ex.Message + "\n\nCannot create file" + saveFileDialog.FileName;
                    MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                writer.WriteLine(dataGridView1.RowCount - 1);
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    writer.WriteLine(dataGridView1.Rows[i].Cells[0].Value?.ToString() ?? "");
                    writer.WriteLine(dataGridView1.Rows[i].Cells[1].Value?.ToString() ?? "");
                }

                writer.Close();
                strm.Close();

                MessageBox.Show("File Saved!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyUp(r);
            TurnOff();
            timer1.Start();
            label2.Text = "Running";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TurnOff();
            timer1.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KeyUp(r);
            TurnOff();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TurnOff();
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./background.jpg");
                this.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading background image: " + ex.Message);
            }
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        dataGridView1.Rows.Add(reader.ReadLine(), reader.ReadLine());
                    }
                }
            }
        }
    }
}
