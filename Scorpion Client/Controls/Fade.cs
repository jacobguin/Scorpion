using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scorpion_Client.Controls
{
    public class Fader
    {
        // This delegate is later used as a call back for
        // when the form has completed fading.
        public delegate void FadeCompleted();

        // Class properties
        private Form form;             // The form to modify the opacity of.
        private IWin32Window parent;           // The parent form if being displayed as a dialog.
        private FadeDirection fadeDirection;    // The direction in which to fade.
        private float fadeSpeed;        // The speed at which to fade.
        private FadeCompleted fadeFinished;     // The delegate to call when a fade has completed.
        private bool shouldClose;      // If set to true, the form will close after fading out.
        private DialogResult dialogResult;     // The result returned from a dialog box.

        // Enum for controlling the fade direction.
        private enum FadeDirection
        {
            In,
            Out
        }

        // Constants for setting the fade speed. 
        // (You can alternately use a custom float value)
        public static class FadeSpeed
        {
            public static readonly float Slowest = 1;
            public static readonly float Slower = 10;
            public static readonly float Slow = 25;
            public static readonly float Normal = 50;
            public static readonly float Fast = 60;
            public static readonly float Faster = 75;
            public static readonly float Fastest = 100;
        }

        /// <summary>
        /// Construct the Fader object with a form.
        /// </summary>
        private Fader(Form form)
        {
            this.form = form;
        }

        /// <summary>
        /// Construct a Fader object with a form and a parent form.
        /// </summary>
        private Fader(Form form, IWin32Window parent) : this(form)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Begin fading the form.
        /// </summary>
        private DialogResult beginFade()
        {
            while (updateOpacity())
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }

            fadeFinished?.Invoke();

            return dialogResult;
        }

        /// <summary>
        /// Update the opacity of the form using the timer.
        /// </summary>
        private bool updateOpacity()
        {
            if (form.IsDisposed)
                return false;

            switch (fadeDirection)
            {
                // Fade in
                case FadeDirection.In:
                    if (form.Opacity < 1.0)
                        form.Opacity += (fadeSpeed / 1000.0);
                    else
                        return false;

                    break;

                // Fade out
                case FadeDirection.Out:
                    if (form.Opacity > 0.1)
                    {
                        form.Opacity -= (fadeSpeed / 1000.0);
                    }
                    else
                    {
                        if (!shouldClose)
                            form.Hide();
                        else
                            form.Close();

                        return false;
                    }
                    break;
            }

            return true;
        }

        /// <summary>
        /// Fade the form in at the defined speed as a dialog
        /// based on parent form.
        /// </summary>
        private DialogResult showDialog(float fadeSpeed, FadeCompleted finished)
        {
            dialogResult = form.ShowDialog(parent);

            fadeFinished = finished;
            form.Opacity = 0;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.In;

            return beginFade();
        }

        /// <summary>
        /// Fade the form in at the defined speed.
        /// </summary>
        private void fadeIn(float fadeSpeed, FadeCompleted finished)
        {
            form.Opacity = 0;
            form.Show();

            fadeFinished = finished;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.In;

            beginFade();
        }

        /// <summary>
        /// Fade the form out at the defined speed.
        /// </summary>
        private void fadeOut(float fadeSpeed, FadeCompleted finished)
        {
            if (form.Opacity < 0.1)
            {
                finished?.Invoke();
                return;
            }

            fadeFinished = finished;
            form.Opacity = 100;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.Out;

            beginFade();
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed.
        /// </summary>
        public static DialogResult ShowDialog(Form form, Form parent, float fadeSpeed)
        {
            Fader fader = new Fader(form, parent);
            return fader.showDialog(fadeSpeed, null);
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed
        /// and call the finished delegate.)
        /// </summary>
        public static DialogResult ShowDialog(Form form, Form parent, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form, parent);
            return fader.showDialog(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(Form form, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form);
            fader.fadeIn(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(Form form, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form);
            fader.fadeOut(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form);
            fader.fadeIn(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form);
            fader.fadeOut(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed and
        /// close it when the fade has completed.
        /// </summary>
        public static void FadeOutAndClose(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form);
            fader.shouldClose = true;
            fader.fadeOut(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed and
        /// close it when the fade has completed.
        /// After the form has closed, call the FadeComplete delegate.
        /// </summary>
        public static void FadeOutAndClose(Form form, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form);
            fader.shouldClose = true;
            fader.fadeOut(fadeSpeed, finished);
        }
    }
}
