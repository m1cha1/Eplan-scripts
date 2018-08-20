//2018 m1cha1
//Based on ChangePLCMnemonics by NAIROLF script from https://suplanus.de/changeplcmnemonics/
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public partial class frmReplaceText : System.Windows.Forms.Form {
    #region form
    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label FindLbl;
    private System.Windows.Forms.TextBox FindTxtBox;
    private System.Windows.Forms.Label ReplaceLbl;
    private System.Windows.Forms.TextBox ReplaceTxtBox;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox chkboxMatch;
    private System.Windows.Forms.RadioButton rbtnNone;
    private System.Windows.Forms.RadioButton rbtnUpper;
    private System.Windows.Forms.RadioButton rbtnLower;
    private System.Windows.Forms.Label ChangeLbl;

    /// <summary>
    /// Disposes resources used by the form.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose ();
        }
        base.Dispose (disposing);
    }

    /// <summary>
    /// This method is required for Windows Forms designer support.
    /// Do not change the method contents inside the source code editor. The Forms designer might
    /// not be able to load this method if it was changed manually.
    /// </summary>
    private void InitializeComponent () {
        this.btnOK = new System.Windows.Forms.Button ();
        this.btnCancel = new System.Windows.Forms.Button ();
        this.FindLbl = new System.Windows.Forms.Label ();
        this.ReplaceLbl = new System.Windows.Forms.Label ();
        this.FindTxtBox = new System.Windows.Forms.TextBox ();
        this.ReplaceTxtBox = new System.Windows.Forms.TextBox ();
        this.chkboxMatch = new System.Windows.Forms.CheckBox ();
        this.rbtnNone = new System.Windows.Forms.RadioButton ();
        this.rbtnUpper = new System.Windows.Forms.RadioButton ();
        this.rbtnLower = new System.Windows.Forms.RadioButton ();
        this.ChangeLbl = new System.Windows.Forms.Label ();
        this.SuspendLayout ();
        // 
        // btnOK
        // 
        this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.btnOK.Location = new System.Drawing.Point (215, 188);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size (120, 23);
        this.btnOK.TabIndex = 5;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        this.btnOK.Click += new System.EventHandler (this.btnOK_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point (352, 188);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size (120, 23);
        this.btnCancel.TabIndex = 6;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler (this.btnCancel_Click);
        // 
        // FindLbl
        // 
        this.FindLbl.Location = new System.Drawing.Point (12, 9);
        this.FindLbl.Name = "FindLbl";
        this.FindLbl.Size = new System.Drawing.Size (100, 16);
        this.FindLbl.TabIndex = 0;
        this.FindLbl.Text = "Find &what:";
        // 
        // ReplaceLbl
        // 
        this.ReplaceLbl.Location = new System.Drawing.Point (12, 57);
        this.ReplaceLbl.Name = "ReplaceLbl";
        this.ReplaceLbl.Size = new System.Drawing.Size (100, 16);
        this.ReplaceLbl.TabIndex = 0;
        this.ReplaceLbl.Text = "&Replace with:";
        // 
        // FindTxtBox
        // 
        this.FindTxtBox.Location = new System.Drawing.Point (12, 28);
        this.FindTxtBox.Name = "FindTxtBox";
        this.FindTxtBox.Size = new System.Drawing.Size (460, 20);
        this.FindTxtBox.TabIndex = 1;
        // 
        // ReplaceTxtBox
        // 
        this.ReplaceTxtBox.Location = new System.Drawing.Point (12, 76);
        this.ReplaceTxtBox.Name = "ReplaceTxtBox";
        this.ReplaceTxtBox.Size = new System.Drawing.Size (460, 20);
        this.ReplaceTxtBox.TabIndex = 2;
        // 
        // chkboxMatch
        // 
        this.chkboxMatch.Checked = true;
        this.chkboxMatch.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkboxMatch.Location = new System.Drawing.Point (12, 102);
        this.chkboxMatch.Name = "chkboxMatch";
        this.chkboxMatch.Size = new System.Drawing.Size (104, 24);
        this.chkboxMatch.TabIndex = 3;
        this.chkboxMatch.Text = "&Match case";
        this.chkboxMatch.UseVisualStyleBackColor = true;
        // 
        // rbtnNone
        // 
        this.rbtnNone.Checked = true;
        this.rbtnNone.Location = new System.Drawing.Point (12, 148);
        this.rbtnNone.Name = "rbtnNone";
        this.rbtnNone.Size = new System.Drawing.Size (57, 24);
        this.rbtnNone.TabIndex = 4;
        this.rbtnNone.TabStop = true;
        this.rbtnNone.Text = "None";
        this.rbtnNone.UseVisualStyleBackColor = true;
        // 
        // rbtnUpper
        // 
        this.rbtnUpper.Location = new System.Drawing.Point (86, 148);
        this.rbtnUpper.Name = "rbtnUpper";
        this.rbtnUpper.Size = new System.Drawing.Size (95, 24);
        this.rbtnUpper.TabIndex = 4;
        this.rbtnUpper.Text = "UPPERCASE";
        this.rbtnUpper.UseVisualStyleBackColor = true;
        // 
        // rbtnLower
        // 
        this.rbtnLower.Location = new System.Drawing.Point (200, 148);
        this.rbtnLower.Name = "rbtnLower";
        this.rbtnLower.Size = new System.Drawing.Size (81, 24);
        this.rbtnLower.TabIndex = 4;
        this.rbtnLower.Text = "lowercase";
        this.rbtnLower.UseVisualStyleBackColor = true;
        // 
        // ChangeLbl
        // 
        this.ChangeLbl.Location = new System.Drawing.Point (12, 129);
        this.ChangeLbl.Name = "ChangeLbl";
        this.ChangeLbl.Size = new System.Drawing.Size (100, 16);
        this.ChangeLbl.TabIndex = 0;
        this.ChangeLbl.Text = "Change case:";
        // 
        // frmReplaceText
        // 
        this.AcceptButton = this.btnOK;
        this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size (484, 227);
        this.Controls.Add (this.rbtnLower);
        this.Controls.Add (this.rbtnUpper);
        this.Controls.Add (this.rbtnNone);
        this.Controls.Add (this.chkboxMatch);
        this.Controls.Add (this.btnCancel);
        this.Controls.Add (this.btnOK);
        this.Controls.Add (this.ReplaceTxtBox);
        this.Controls.Add (this.FindTxtBox);
        this.Controls.Add (this.ReplaceLbl);
        this.Controls.Add (this.ChangeLbl);
        this.Controls.Add (this.FindLbl);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmReplaceText";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Replace";
        this.ResumeLayout (false);
        this.PerformLayout ();

    }

    #endregion

    public frmReplaceText () {
        InitializeComponent ();
    }

    public static string sSourceText = string.Empty;
    public static string savedText = string.Empty;

    [DeclareAction ("DialogReplaceText")]
    public void DialogReplaceText_action () {
        frmReplaceText frm = new frmReplaceText ();
        frm.ShowDialog ();
        return;
    }

    private void btnCancel_Click (object sender, System.EventArgs e) {
        Close ();
    }

    private void btnOK_Click (object sender, System.EventArgs e) {
        //remember text in the clipboard
        if (System.Windows.Forms.Clipboard.ContainsText ()) {
            savedText = System.Windows.Forms.Clipboard.GetText ();
        }
        //https://suplanus.de/changeplcmnemonics/
        //clear clipboard
        System.Windows.Forms.Clipboard.Clear ();
        //copy text
        CommandLineInterpreter oCLI = new CommandLineInterpreter ();
        oCLI.Execute ("GfDlgMgrActionIGfWind /function:Copy");
        if (System.Windows.Forms.Clipboard.ContainsText ()) {
            sSourceText = System.Windows.Forms.Clipboard.GetText ();
            if (sSourceText != string.Empty) {
                //Replace
                if (chkboxMatch.Checked | ReplaceTxtBox.Text == "") //Match case or empty
                    sSourceText = sSourceText.Replace (FindTxtBox.Text, ReplaceTxtBox.Text);
                else
                    //Ignore case
                    sSourceText = Regex.Replace (sSourceText, FindTxtBox.Text, ReplaceTxtBox.Text, RegexOptions.IgnoreCase);
                //Change case
                if (rbtnUpper.Checked)
                    sSourceText = sSourceText.ToUpper ();
                else if (rbtnLower.Checked)
                    sSourceText = sSourceText.ToLower ();

                try {
                    System.Windows.Forms.Clipboard.SetText (sSourceText);
                    oCLI.Execute ("GfDlgMgrActionIGfWind /function:Paste"); //Paste text
                    if (savedText != string.Empty)
                        System.Windows.Forms.Clipboard.SetText (savedText); //Put saved text in clipboard
                } catch (System.Exception ex) {
                    MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    [DeclareMenu ()]
    public void CreateContextMenus () {
        Eplan.EplApi.Gui.ContextMenuLocation oCTXLoc = new Eplan.EplApi.Gui.ContextMenuLocation ();
        Eplan.EplApi.Gui.ContextMenu oCTXMenu = new Eplan.EplApi.Gui.ContextMenu ();
        //Edit in table
        try {
            oCTXLoc.DialogName = "XFDGFunctionDataFunctionTabDialog";
            oCTXLoc.ContextMenuName = "1006";
            oCTXMenu.AddMenuItem (oCTXLoc, "Replace text", "DialogReplaceText", false, false);
        } catch (System.Exception ex) {
            MessageBox.Show (ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Addresses / Assignment lists
        try {
            oCTXLoc.DialogName = "XPlcIoDataDlg";
            oCTXLoc.ContextMenuName = "1024";
            oCTXMenu.AddMenuItem (oCTXLoc, "Replace text", "DialogReplaceText", false, false);
        } catch (System.Exception ex) {
            MessageBox.Show (ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Text editing
        try {
            oCTXLoc.DialogName = "GedEditGuiText";
            oCTXLoc.ContextMenuName = "1002";
            oCTXMenu.AddMenuItem (oCTXLoc, "Replace text", "DialogReplaceText", false, false);
        } catch (System.Exception ex) {
            MessageBox.Show (ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Paste pages
        try {
            oCTXLoc.DialogName = "PmPageAssimilatePageTabDlg";
            oCTXLoc.ContextMenuName = "1044";
            oCTXMenu.AddMenuItem (oCTXLoc, "Replace text", "DialogReplaceText", false, false);
        } catch (System.Exception ex) {
            MessageBox.Show (ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}