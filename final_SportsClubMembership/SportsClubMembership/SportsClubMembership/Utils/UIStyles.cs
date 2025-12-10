using System.Drawing;
using System.Windows.Forms;

public static class UIStyles
{
    public static Color Primary = Color.FromArgb(30, 58, 138);
    public static Color Secondary = Color.White;
    public static Color Background = Color.FromArgb(224, 242, 254);
    public static Color TextDark = Color.FromArgb(30, 41, 59);
    public static Color Success = Color.FromArgb(46, 204, 113);
    public static Color Danger = Color.FromArgb(231, 76, 60);
    public static Color BorderSoft = Color.FromArgb(203, 213, 225);

    public static Font TitleFont = new Font("Segoe UI", 18, FontStyle.Bold);
    public static Font SubtitleFont = new Font("Segoe UI", 12, FontStyle.Regular);
    public static Font NormalFont = new Font("Segoe UI", 10);

    public static void ApplyFormStyle(Form f)
    {
        f.BackColor = Background;
        f.Font = NormalFont;
        f.StartPosition = FormStartPosition.CenterScreen;
        f.ClientSize = new Size(900, 600);

        ApplyControlStyles(f);
    }

    private static void ApplyControlStyles(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is Label lbl)
                lbl.ForeColor = TextDark;

            if (c is TextBox tb)
            {
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.BackColor = Color.White;
            }

            if (c is ComboBox cb)
            {
                cb.BackColor = Color.White;
                cb.FlatStyle = FlatStyle.Flat;
            }

            if (c is Button btn)
                StyleButton(btn);

            if (c.HasChildren)
                ApplyControlStyles(c);
        }
    }

    public static void StyleButton(Button b)
    {
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.Height = 40;
        b.Width = 160;
        b.ForeColor = Color.White;
        b.BackColor = Primary;

        // Hover effect
        b.MouseEnter += (s, e) => b.BackColor = ControlPaint.Light(Primary);
        b.MouseLeave += (s, e) => b.BackColor = Primary;
    }

    public static Button PrimaryButton(string text)
    {
        var btn = new Button()
        {
            Text = text,
            BackColor = Primary,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 40,
            Width = 160
        };

        btn.FlatAppearance.BorderSize = 0;
        btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(Primary);
        btn.MouseLeave += (s, e) => btn.BackColor = Primary;

        return btn;
    }

    public static Button SuccessButton(string text)
    {
        var btn = PrimaryButton(text);
        btn.BackColor = Success;
        btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(Success);
        btn.MouseLeave += (s, e) => btn.BackColor = Success;
        return btn;
    }

    public static Button DangerButton(string text)
    {
        var btn = PrimaryButton(text);
        btn.BackColor = Danger;
        btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(Danger);
        btn.MouseLeave += (s, e) => btn.BackColor = Danger;
        return btn;
    }

    public static Label Title(string text)
    {
        return new Label()
        {
            Text = text,
            Font = TitleFont,
            ForeColor = Primary,
            AutoSize = true
        };
    }

    public static Label Subtitle(string text)
    {
        return new Label()
        {
            Text = text,
            Font = SubtitleFont,
            ForeColor = TextDark,
            AutoSize = true
        };
    }

    public static Panel CardPanel()
    {
        return new Panel()
        {
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Width = 240,
            Height = 330,
            Margin = new Padding(12),
            Padding = new Padding(12)
        };
    }

    public static void StyleDataGrid(DataGridView dgv)
    {
        dgv.BackgroundColor = Background;
        dgv.BorderStyle = BorderStyle.None;
        dgv.EnableHeadersVisualStyles = false;

        dgv.ColumnHeadersDefaultCellStyle.BackColor = Primary;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        dgv.DefaultCellStyle.BackColor = Color.White;
        dgv.DefaultCellStyle.ForeColor = TextDark;
        dgv.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(Primary);

        dgv.RowHeadersVisible = false;
        dgv.GridColor = BorderSoft;
    }
}
