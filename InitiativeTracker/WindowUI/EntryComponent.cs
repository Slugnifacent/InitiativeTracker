using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitiativeTracker.WindowUI
{

    // Entry Encapsulation 
    public class EntryComponent
    {
        string key;
        string value;
        GuiType type;
        Control control;
        Action<EntryComponent> buttonPress;

        // Optional Entry Parent
        Entry parent;

        public enum GuiType {
            LABEL,
            BUTTON,
            TEXTBOX
        }

        public EntryComponent(string Key, string Value, GuiType guiType, Action<EntryComponent> ButtonPress)
        {
            key = Key;
            value = Value;
            type = guiType;
            switch (type)
            {
                case GuiType.LABEL:
                    control = CreateLabel(key, value);
                    break;
                case GuiType.BUTTON:
                    control = CreateButton(key, value);
                    break;
                case GuiType.TEXTBOX:
                    control = CreateTextBox(key, value);
                    break;
            }
            control.Visible = true;
            buttonPress = ButtonPress;
        }

        // Label Creation Helper
        private Label CreateLabel(string Name, string Text)
        {
            Label label = new Label();
            label.Name = Name;
            label.AutoSize = true;
            label.Text = Text;
            label.Size = new Size(50, 20);
            label.Font = new Font("Arial", 12, FontStyle.Regular);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Click += onClick;
            return label;
        }

        private void onClick(object sender, EventArgs e)
        {
            if(buttonPress != null) buttonPress(this);
        }

        // Button Creation Helper
        private Button CreateButton(string Name, string Text)
        {
            Button button = new Button();
            button.Name = Name;
            button.Text = Text;
            button.Dock = DockStyle.Fill;
            button.Click += onClick;
            return button;
        }

        // Button Creation Helper
        private TextBox CreateTextBox(string Name, string Text)
        {
            TextBox text = new TextBox();
            text.Name = Name;
            text.Text = Text;
            text.Dock = DockStyle.Fill;
            return text;
        }


        //Set Entry Parent
        public void SetEntryParent(Entry _Parent)
        {
            parent = _Parent;
        }

        // Properties
        public string Key
        {
            get { return key; }
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Control Control
        {
            get { return control; }
        }

        public Entry Parent
        {
            get { return parent; }
        }

        public string toString()
        {
            return string.Format("{0} {1}\n ", key,value);
        }
    }
}
