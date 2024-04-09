namespace JurDocs.WinForms
{
    public static class ProgramHelpers
    {

        public static void MoveWindowToCenterScreen(Form form)
        {
            var screen = Screen.FromControl(form);
            form.Top = screen.Bounds.Height / 2 - form.Height / 2;
            form.Left = screen.Bounds.Width / 2 - form.Width / 2;
        }
    }
}