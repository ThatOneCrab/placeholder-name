using SysBot.Pokemon.WinForms.Properties;

namespace SysBot.Pokemon.WinForms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TC_Main = new System.Windows.Forms.TabControl();
            Tab_Bots = new System.Windows.Forms.TabPage();
            CB_Protocol = new System.Windows.Forms.ComboBox();
            FLP_Bots = new System.Windows.Forms.FlowLayoutPanel();
            TB_IP = new System.Windows.Forms.TextBox();
            CB_Routine = new System.Windows.Forms.ComboBox();
            NUD_Port = new System.Windows.Forms.NumericUpDown();
            B_New = new System.Windows.Forms.Button();
            Tab_Hub = new System.Windows.Forms.TabPage();
            PG_Hub = new System.Windows.Forms.PropertyGrid();
            Tab_Logs = new System.Windows.Forms.TabPage();
            RTB_Logs = new System.Windows.Forms.RichTextBox();
            B_Stop = new System.Windows.Forms.Button();
            B_Start = new System.Windows.Forms.Button();
            B_RebootStop = new System.Windows.Forms.Button();
            TC_Main.SuspendLayout();
            Tab_Bots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Port).BeginInit();
            Tab_Hub.SuspendLayout();
            Tab_Logs.SuspendLayout();
            SuspendLayout();
            // 
            // TC_Main
            // 
            TC_Main.Controls.Add(Tab_Bots);
            TC_Main.Controls.Add(Tab_Hub);
            TC_Main.Controls.Add(Tab_Logs);
            TC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            TC_Main.Location = new System.Drawing.Point(0, 0);
            TC_Main.Margin = new System.Windows.Forms.Padding(4);
            TC_Main.Name = "TC_Main";
            TC_Main.SelectedIndex = 0;
            TC_Main.Size = new System.Drawing.Size(827, 414);
            TC_Main.TabIndex = 3;
            // 
            // Tab_Bots
            // 
            Tab_Bots.BackColor = System.Drawing.Color.Black;
            Tab_Bots.Controls.Add(CB_Protocol);
            Tab_Bots.Controls.Add(FLP_Bots);
            Tab_Bots.Controls.Add(TB_IP);
            Tab_Bots.Controls.Add(CB_Routine);
            Tab_Bots.Controls.Add(NUD_Port);
            Tab_Bots.Controls.Add(B_New);
            Tab_Bots.Location = new System.Drawing.Point(4, 24);
            Tab_Bots.Margin = new System.Windows.Forms.Padding(4);
            Tab_Bots.Name = "Tab_Bots";
            Tab_Bots.Size = new System.Drawing.Size(819, 386);
            Tab_Bots.TabIndex = 0;
            Tab_Bots.Text = "Bots";
            // 
            // CB_Protocol
            // 
            CB_Protocol.BackColor = System.Drawing.Color.Black;
            CB_Protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_Protocol.ForeColor = System.Drawing.Color.White;
            CB_Protocol.FormattingEnabled = true;
            CB_Protocol.Location = new System.Drawing.Point(290, 6);
            CB_Protocol.Margin = new System.Windows.Forms.Padding(4);
            CB_Protocol.Name = "CB_Protocol";
            CB_Protocol.Size = new System.Drawing.Size(67, 23);
            CB_Protocol.TabIndex = 10;
            CB_Protocol.SelectedIndexChanged += CB_Protocol_SelectedIndexChanged;
            // 
            // FLP_Bots
            // 
            FLP_Bots.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            FLP_Bots.BackColor = System.Drawing.Color.Black;
            FLP_Bots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            FLP_Bots.ForeColor = System.Drawing.Color.White;
            FLP_Bots.Location = new System.Drawing.Point(0, 37);
            FLP_Bots.Margin = new System.Windows.Forms.Padding(0);
            FLP_Bots.Name = "FLP_Bots";
            FLP_Bots.Size = new System.Drawing.Size(817, 347);
            FLP_Bots.TabIndex = 9;
            FLP_Bots.Paint += FLP_Bots_Paint;
            FLP_Bots.Resize += FLP_Bots_Resize;
            // 
            // TB_IP
            // 
            TB_IP.BackColor = System.Drawing.Color.Black;
            TB_IP.Font = new System.Drawing.Font("Courier New", 8.25F);
            TB_IP.ForeColor = System.Drawing.Color.White;
            TB_IP.Location = new System.Drawing.Point(74, 7);
            TB_IP.Margin = new System.Windows.Forms.Padding(4);
            TB_IP.Name = "TB_IP";
            TB_IP.Size = new System.Drawing.Size(134, 20);
            TB_IP.TabIndex = 8;
            TB_IP.Text = "192.168.0.1";
            // 
            // CB_Routine
            // 
            CB_Routine.BackColor = System.Drawing.Color.Black;
            CB_Routine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_Routine.ForeColor = System.Drawing.Color.White;
            CB_Routine.FormattingEnabled = true;
            CB_Routine.Location = new System.Drawing.Point(364, 6);
            CB_Routine.Margin = new System.Windows.Forms.Padding(4);
            CB_Routine.Name = "CB_Routine";
            CB_Routine.Size = new System.Drawing.Size(117, 23);
            CB_Routine.TabIndex = 7;
            // 
            // NUD_Port
            // 
            NUD_Port.BackColor = System.Drawing.Color.Black;
            NUD_Port.Font = new System.Drawing.Font("Courier New", 8.25F);
            NUD_Port.ForeColor = System.Drawing.Color.White;
            NUD_Port.Location = new System.Drawing.Point(214, 7);
            NUD_Port.Margin = new System.Windows.Forms.Padding(4);
            NUD_Port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_Port.Name = "NUD_Port";
            NUD_Port.Size = new System.Drawing.Size(67, 20);
            NUD_Port.TabIndex = 6;
            NUD_Port.Value = new decimal(new int[] { 6000, 0, 0, 0 });
            NUD_Port.ValueChanged += NUD_Port_ValueChanged;
            // 
            // B_New
            // 
            B_New.BackColor = System.Drawing.Color.DimGray;
            B_New.ForeColor = System.Drawing.Color.White;
            B_New.Location = new System.Drawing.Point(4, 7);
            B_New.Margin = new System.Windows.Forms.Padding(4);
            B_New.Name = "B_New";
            B_New.Size = new System.Drawing.Size(63, 23);
            B_New.TabIndex = 0;
            B_New.Text = "Add";
            B_New.UseVisualStyleBackColor = false;
            B_New.Click += B_New_Click;
            // 
            // Tab_Hub
            // 
            Tab_Hub.Controls.Add(PG_Hub);
            Tab_Hub.Location = new System.Drawing.Point(4, 24);
            Tab_Hub.Margin = new System.Windows.Forms.Padding(4);
            Tab_Hub.Name = "Tab_Hub";
            Tab_Hub.Padding = new System.Windows.Forms.Padding(4);
            Tab_Hub.Size = new System.Drawing.Size(819, 386);
            Tab_Hub.TabIndex = 2;
            Tab_Hub.Text = "Hub";
            Tab_Hub.UseVisualStyleBackColor = true;
            // 
            // PG_Hub
            // 
            PG_Hub.BackColor = System.Drawing.Color.Black;
            PG_Hub.CategoryForeColor = System.Drawing.Color.White;
            PG_Hub.CategorySplitterColor = System.Drawing.Color.DimGray;
            PG_Hub.CommandsActiveLinkColor = System.Drawing.Color.BlanchedAlmond;
            PG_Hub.CommandsBackColor = System.Drawing.Color.BlanchedAlmond;
            PG_Hub.CommandsDisabledLinkColor = System.Drawing.Color.BlanchedAlmond;
            PG_Hub.CommandsForeColor = System.Drawing.Color.Red;
            PG_Hub.DisabledItemForeColor = System.Drawing.Color.FromArgb(127, 255, 255, 255);
            PG_Hub.Dock = System.Windows.Forms.DockStyle.Fill;
            PG_Hub.HelpBackColor = System.Drawing.Color.Black;
            PG_Hub.HelpForeColor = System.Drawing.Color.White;
            PG_Hub.LineColor = System.Drawing.Color.Transparent;
            PG_Hub.Location = new System.Drawing.Point(4, 4);
            PG_Hub.Margin = new System.Windows.Forms.Padding(4);
            PG_Hub.Name = "PG_Hub";
            PG_Hub.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            PG_Hub.Size = new System.Drawing.Size(811, 378);
            PG_Hub.TabIndex = 0;
            PG_Hub.ViewBackColor = System.Drawing.Color.Black;
            PG_Hub.ViewBorderColor = System.Drawing.Color.Black;
            PG_Hub.ViewForeColor = System.Drawing.Color.White;
            PG_Hub.Click += PG_Hub_Click;
            // 
            // Tab_Logs
            // 
            Tab_Logs.Controls.Add(RTB_Logs);
            Tab_Logs.Location = new System.Drawing.Point(4, 24);
            Tab_Logs.Margin = new System.Windows.Forms.Padding(4);
            Tab_Logs.Name = "Tab_Logs";
            Tab_Logs.Size = new System.Drawing.Size(819, 386);
            Tab_Logs.TabIndex = 1;
            Tab_Logs.Text = "Logs";
            Tab_Logs.UseVisualStyleBackColor = true;
            // 
            // RTB_Logs
            // 
            RTB_Logs.BackColor = System.Drawing.Color.Black;
            RTB_Logs.Dock = System.Windows.Forms.DockStyle.Fill;
            RTB_Logs.ForeColor = System.Drawing.Color.White;
            RTB_Logs.Location = new System.Drawing.Point(0, 0);
            RTB_Logs.Margin = new System.Windows.Forms.Padding(4);
            RTB_Logs.Name = "RTB_Logs";
            RTB_Logs.ReadOnly = true;
            RTB_Logs.Size = new System.Drawing.Size(819, 386);
            RTB_Logs.TabIndex = 0;
            RTB_Logs.Text = "";
            // 
            // B_Stop
            // 
            B_Stop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            B_Stop.BackColor = System.Drawing.Color.Crimson;
            B_Stop.ForeColor = System.Drawing.Color.White;
            B_Stop.Location = new System.Drawing.Point(571, 0);
            B_Stop.Margin = new System.Windows.Forms.Padding(4);
            B_Stop.Name = "B_Stop";
            B_Stop.Size = new System.Drawing.Size(69, 23);
            B_Stop.TabIndex = 4;
            B_Stop.Text = "Stop All";
            B_Stop.UseVisualStyleBackColor = false;
            B_Stop.Click += B_Stop_Click;
            // 
            // B_Start
            // 
            B_Start.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            B_Start.BackColor = System.Drawing.Color.Green;
            B_Start.ForeColor = System.Drawing.Color.White;
            B_Start.Location = new System.Drawing.Point(495, 0);
            B_Start.Margin = new System.Windows.Forms.Padding(4);
            B_Start.Name = "B_Start";
            B_Start.Size = new System.Drawing.Size(69, 23);
            B_Start.TabIndex = 3;
            B_Start.Text = "Start All";
            B_Start.UseVisualStyleBackColor = false;
            B_Start.Click += B_Start_Click;
            // 
            // B_RebootStop
            // 
            B_RebootStop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            B_RebootStop.BackColor = System.Drawing.Color.Black;
            B_RebootStop.ForeColor = System.Drawing.Color.White;
            B_RebootStop.Location = new System.Drawing.Point(648, 0);
            B_RebootStop.Margin = new System.Windows.Forms.Padding(4);
            B_RebootStop.Name = "B_RebootStop";
            B_RebootStop.Size = new System.Drawing.Size(121, 23);
            B_RebootStop.TabIndex = 3;
            B_RebootStop.Text = "Reboot And Stop";
            B_RebootStop.UseVisualStyleBackColor = false;
            B_RebootStop.Click += B_RebootStop_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(827, 414);
            Controls.Add(B_Stop);
            Controls.Add(B_Start);
            Controls.Add(B_RebootStop);
            Controls.Add(TC_Main);
            Icon = Resources.icon;
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "Main";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SysBot: Pokémon";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            TC_Main.ResumeLayout(false);
            Tab_Bots.ResumeLayout(false);
            Tab_Bots.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Port).EndInit();
            Tab_Hub.ResumeLayout(false);
            Tab_Logs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl TC_Main;
        private System.Windows.Forms.TabPage Tab_Bots;
        private System.Windows.Forms.TabPage Tab_Logs;
        private System.Windows.Forms.RichTextBox RTB_Logs;
        private System.Windows.Forms.TabPage Tab_Hub;
        private System.Windows.Forms.PropertyGrid PG_Hub;
        private System.Windows.Forms.Button B_Stop;
        private System.Windows.Forms.Button B_Start;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.ComboBox CB_Routine;
        private System.Windows.Forms.NumericUpDown NUD_Port;
        private System.Windows.Forms.Button B_New;
        private System.Windows.Forms.FlowLayoutPanel FLP_Bots;
        private System.Windows.Forms.ComboBox CB_Protocol;
        private System.Windows.Forms.Button B_RebootStop;
    }
}

