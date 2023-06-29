using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YoketoruCS
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        //—ñ‹“Žqenum
        enum State
        {
            None = -1,
            Title,
            Game,
            Gameover,
            Clear
        }

        State nextState = State.Title;
        State currentState = State.None;

        int score;
        int timer;
        int

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeState();
            UpdateState();
        }

        void ChangeState()
        {
            if (nextState == State.None) return;

            currentState = nextState;
            nextState = State.None;

            switch (currentState)
            {
                case State.Title:
                    labelTitle.visible = true;
                    buttonStart.visible = true;
                    labelGameover.visible = false;
                    buttonTitle.visible = false;
                    labelClear.visible = false;
                    labelHighScore.Visible = true;
                    tempPlayer.Visible = false;
                    tempObstacle.Visible = false;
                    tempItem.Visible = false;
                    labelCopyright.Visible = true;
                    break;

                case State.Game:
                    labelTitle.visible = false;
                    buttonStart.visible = false;
                    labelHighScore.visible = false;
                    labelCopyright.visible = false;
                    break;

                case State.Gameover:
                    labelGameover.Visible = true;
                    buttonTitle.Visible = true;
                    labelHighScore.Visible = true;
                    break;

                case State.Clear:
                    labelClear.Visible = true;
                    buttonTitle.Visible = true;
                    labelHighScore.Visible = true;
                    break;
            }
        }

        void UpdateState()
        {
            switch (currentState)
            {
                case State.Game:
                    UpdateGame();
                    break;
            }
        }

        void UpdateGame()
        {
            if (GetAsyncKeyState((int)Keys.O) < 0)
            {
                nextState = State.Gameover;
            }
        }


        private void ‚æ‚¯‚Æ‚éCS_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        {
            nextState = State.Game;
        }

        //private void button2_Click(object sender, EventArgs e)
        {
            nextState = State.Title;
        }
    }
}