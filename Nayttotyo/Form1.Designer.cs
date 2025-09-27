namespace Nayttotyo
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            linkLabel1 = new LinkLabel();
            ChessPieces = new ImageList(components);
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            BlackKing = new PictureBox();
            BlackQueen = new PictureBox();
            BlackRook2 = new PictureBox();
            BlackPawn5 = new PictureBox();
            BlackPawn2 = new PictureBox();
            WhitePawn1 = new PictureBox();
            WhitePawn2 = new PictureBox();
            WhitePawn3 = new PictureBox();
            WhitePawn4 = new PictureBox();
            WhitePawn5 = new PictureBox();
            WhitePawn6 = new PictureBox();
            WhitePawn7 = new PictureBox();
            WhitePawn8 = new PictureBox();
            WhiteRook2 = new PictureBox();
            WhiteKing = new PictureBox();
            WhiteRook1 = new PictureBox();
            WhiteQueen = new PictureBox();
            BlackPawn1 = new PictureBox();
            BlackPawn3 = new PictureBox();
            BlackPawn4 = new PictureBox();
            BlackPawn6 = new PictureBox();
            BlackPawn7 = new PictureBox();
            BlackPawn8 = new PictureBox();
            BlackRook1 = new PictureBox();
            BlackBishop2 = new PictureBox();
            BlackBishop1 = new PictureBox();
            BlackKnight1 = new PictureBox();
            BlackKnight2 = new PictureBox();
            WhiteKnight2 = new PictureBox();
            WhiteBishop2 = new PictureBox();
            WhiteBishop1 = new PictureBox();
            WhiteKnight1 = new PictureBox();
            Tiles = new ImageList(components);
            button1 = new Button();
            label1 = new Label();
            imageList1 = new ImageList(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BlackKing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackQueen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackRook2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteRook2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteKing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteRook1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteQueen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackRook1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackBishop2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackBishop1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackKnight1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlackKnight2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteKnight2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteBishop2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteBishop1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhiteKnight1).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(210, 217);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(0, 25);
            linkLabel1.TabIndex = 8;
            // 
            // ChessPieces
            // 
            ChessPieces.ColorDepth = ColorDepth.Depth32Bit;
            ChessPieces.ImageStream = (ImageListStreamer)resources.GetObject("ChessPieces.ImageStream");
            ChessPieces.TransparentColor = Color.Transparent;
            ChessPieces.Images.SetKeyName(0, "Chess_rlt60.png");
            ChessPieces.Images.SetKeyName(1, "Chess_rdt60.png");
            ChessPieces.Images.SetKeyName(2, "Chess_qlt60.png");
            ChessPieces.Images.SetKeyName(3, "Chess_qdt60.png");
            ChessPieces.Images.SetKeyName(4, "Chess_plt60.png");
            ChessPieces.Images.SetKeyName(5, "Chess_pdt60.png");
            ChessPieces.Images.SetKeyName(6, "Chess_nlt60.png");
            ChessPieces.Images.SetKeyName(7, "Chess_ndt60.png");
            ChessPieces.Images.SetKeyName(8, "Chess_klt60.png");
            ChessPieces.Images.SetKeyName(9, "Chess_kdt60.png");
            ChessPieces.Images.SetKeyName(10, "Chess_blt60.png");
            ChessPieces.Images.SetKeyName(11, "Chess_bdt60.png");
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackgroundImage = (Image)resources.GetObject("tableLayoutPanel1.BackgroundImage");
            tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(BlackKing, 4, 0);
            tableLayoutPanel1.Controls.Add(BlackQueen, 3, 0);
            tableLayoutPanel1.Controls.Add(BlackRook2, 7, 0);
            tableLayoutPanel1.Controls.Add(BlackPawn5, 4, 1);
            tableLayoutPanel1.Controls.Add(BlackPawn2, 1, 1);
            tableLayoutPanel1.Controls.Add(WhitePawn1, 0, 6);
            tableLayoutPanel1.Controls.Add(WhitePawn2, 1, 6);
            tableLayoutPanel1.Controls.Add(WhitePawn3, 2, 6);
            tableLayoutPanel1.Controls.Add(WhitePawn4, 3, 6);
            tableLayoutPanel1.Controls.Add(WhitePawn5, 4, 6);
            tableLayoutPanel1.Controls.Add(WhitePawn6, 5, 6);
            tableLayoutPanel1.Controls.Add(WhitePawn7, 6, 6);
            tableLayoutPanel1.Controls.Add(WhitePawn8, 7, 6);
            tableLayoutPanel1.Controls.Add(WhiteRook2, 7, 7);
            tableLayoutPanel1.Controls.Add(WhiteKing, 4, 7);
            tableLayoutPanel1.Controls.Add(WhiteRook1, 0, 7);
            tableLayoutPanel1.Controls.Add(WhiteQueen, 3, 7);
            tableLayoutPanel1.Controls.Add(BlackPawn1, 0, 1);
            tableLayoutPanel1.Controls.Add(BlackPawn3, 2, 1);
            tableLayoutPanel1.Controls.Add(BlackPawn4, 3, 1);
            tableLayoutPanel1.Controls.Add(BlackPawn6, 5, 1);
            tableLayoutPanel1.Controls.Add(BlackPawn7, 6, 1);
            tableLayoutPanel1.Controls.Add(BlackPawn8, 7, 1);
            tableLayoutPanel1.Controls.Add(BlackRook1, 0, 0);
            tableLayoutPanel1.Controls.Add(BlackBishop2, 5, 0);
            tableLayoutPanel1.Controls.Add(BlackBishop1, 2, 0);
            tableLayoutPanel1.Controls.Add(BlackKnight1, 1, 0);
            tableLayoutPanel1.Controls.Add(BlackKnight2, 6, 0);
            tableLayoutPanel1.Controls.Add(WhiteKnight2, 6, 7);
            tableLayoutPanel1.Controls.Add(WhiteBishop2, 5, 7);
            tableLayoutPanel1.Controls.Add(WhiteBishop1, 2, 7);
            tableLayoutPanel1.Controls.Add(WhiteKnight1, 1, 7);
            tableLayoutPanel1.Location = new Point(87, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(520, 520);
            tableLayoutPanel1.TabIndex = 9;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // BlackKing
            // 
            BlackKing.BackColor = Color.Transparent;
            BlackKing.Image = (Image)resources.GetObject("BlackKing.Image");
            BlackKing.Location = new Point(263, 3);
            BlackKing.Name = "BlackKing";
            BlackKing.Size = new Size(59, 58);
            BlackKing.TabIndex = 39;
            BlackKing.TabStop = false;
            BlackKing.Tag = "BK";
            BlackKing.Click += BlackKing_Click;
            // 
            // BlackQueen
            // 
            BlackQueen.BackColor = Color.Transparent;
            BlackQueen.Image = (Image)resources.GetObject("BlackQueen.Image");
            BlackQueen.Location = new Point(198, 3);
            BlackQueen.Name = "BlackQueen";
            BlackQueen.Size = new Size(59, 58);
            BlackQueen.TabIndex = 38;
            BlackQueen.TabStop = false;
            BlackQueen.Tag = "BQ";
            BlackQueen.Click += BlackQueen_Click;
            // 
            // BlackRook2
            // 
            BlackRook2.BackColor = Color.Transparent;
            BlackRook2.Image = (Image)resources.GetObject("BlackRook2.Image");
            BlackRook2.Location = new Point(458, 3);
            BlackRook2.Name = "BlackRook2";
            BlackRook2.Size = new Size(59, 58);
            BlackRook2.TabIndex = 37;
            BlackRook2.TabStop = false;
            BlackRook2.Tag = "BR";
            BlackRook2.Click += BlackRook2_Click;
            // 
            // BlackPawn5
            // 
            BlackPawn5.BackColor = Color.Transparent;
            BlackPawn5.Image = (Image)resources.GetObject("BlackPawn5.Image");
            BlackPawn5.Location = new Point(263, 68);
            BlackPawn5.Name = "BlackPawn5";
            BlackPawn5.Size = new Size(59, 58);
            BlackPawn5.TabIndex = 28;
            BlackPawn5.TabStop = false;
            BlackPawn5.Tag = "BP";
            BlackPawn5.Click += BlackPawn5_Click;
            // 
            // BlackPawn2
            // 
            BlackPawn2.BackColor = Color.Transparent;
            BlackPawn2.Image = (Image)resources.GetObject("BlackPawn2.Image");
            BlackPawn2.Location = new Point(68, 68);
            BlackPawn2.Name = "BlackPawn2";
            BlackPawn2.Size = new Size(59, 58);
            BlackPawn2.TabIndex = 27;
            BlackPawn2.TabStop = false;
            BlackPawn2.Tag = "BP";
            BlackPawn2.Click += BlackPawn2_Click;
            // 
            // WhitePawn1
            // 
            WhitePawn1.BackColor = Color.Transparent;
            WhitePawn1.Image = (Image)resources.GetObject("WhitePawn1.Image");
            WhitePawn1.Location = new Point(3, 393);
            WhitePawn1.Name = "WhitePawn1";
            WhitePawn1.Size = new Size(59, 57);
            WhitePawn1.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn1.TabIndex = 10;
            WhitePawn1.TabStop = false;
            WhitePawn1.Tag = "WP";
            WhitePawn1.Click += WhitePawn1_Click;
            // 
            // WhitePawn2
            // 
            WhitePawn2.BackColor = Color.Transparent;
            WhitePawn2.Image = (Image)resources.GetObject("WhitePawn2.Image");
            WhitePawn2.Location = new Point(68, 393);
            WhitePawn2.Name = "WhitePawn2";
            WhitePawn2.Size = new Size(59, 57);
            WhitePawn2.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn2.TabIndex = 11;
            WhitePawn2.TabStop = false;
            WhitePawn2.Tag = "WP";
            WhitePawn2.Click += WhitePawn2_Click;
            // 
            // WhitePawn3
            // 
            WhitePawn3.BackColor = Color.Transparent;
            WhitePawn3.Image = (Image)resources.GetObject("WhitePawn3.Image");
            WhitePawn3.Location = new Point(133, 393);
            WhitePawn3.Name = "WhitePawn3";
            WhitePawn3.Size = new Size(59, 57);
            WhitePawn3.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn3.TabIndex = 12;
            WhitePawn3.TabStop = false;
            WhitePawn3.Tag = "WP";
            WhitePawn3.Click += WhitePawn3_Click;
            // 
            // WhitePawn4
            // 
            WhitePawn4.BackColor = Color.Transparent;
            WhitePawn4.Image = (Image)resources.GetObject("WhitePawn4.Image");
            WhitePawn4.Location = new Point(198, 393);
            WhitePawn4.Name = "WhitePawn4";
            WhitePawn4.Size = new Size(59, 57);
            WhitePawn4.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn4.TabIndex = 13;
            WhitePawn4.TabStop = false;
            WhitePawn4.Tag = "WP";
            WhitePawn4.Click += WhitePawn4_Click;
            // 
            // WhitePawn5
            // 
            WhitePawn5.BackColor = Color.Transparent;
            WhitePawn5.Image = (Image)resources.GetObject("WhitePawn5.Image");
            WhitePawn5.Location = new Point(263, 393);
            WhitePawn5.Name = "WhitePawn5";
            WhitePawn5.Size = new Size(59, 57);
            WhitePawn5.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn5.TabIndex = 14;
            WhitePawn5.TabStop = false;
            WhitePawn5.Tag = "WP";
            WhitePawn5.Click += WhitePawn5_Click;
            // 
            // WhitePawn6
            // 
            WhitePawn6.BackColor = Color.Transparent;
            WhitePawn6.Image = (Image)resources.GetObject("WhitePawn6.Image");
            WhitePawn6.Location = new Point(328, 393);
            WhitePawn6.Name = "WhitePawn6";
            WhitePawn6.Size = new Size(59, 57);
            WhitePawn6.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn6.TabIndex = 15;
            WhitePawn6.TabStop = false;
            WhitePawn6.Tag = "WP";
            WhitePawn6.Click += WhitePawn6_Click;
            // 
            // WhitePawn7
            // 
            WhitePawn7.BackColor = Color.Transparent;
            WhitePawn7.Image = (Image)resources.GetObject("WhitePawn7.Image");
            WhitePawn7.Location = new Point(393, 393);
            WhitePawn7.Name = "WhitePawn7";
            WhitePawn7.Size = new Size(59, 58);
            WhitePawn7.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn7.TabIndex = 16;
            WhitePawn7.TabStop = false;
            WhitePawn7.Tag = "WP";
            WhitePawn7.Click += WhitePawn7_Click;
            // 
            // WhitePawn8
            // 
            WhitePawn8.BackColor = Color.Transparent;
            WhitePawn8.Image = (Image)resources.GetObject("WhitePawn8.Image");
            WhitePawn8.Location = new Point(458, 393);
            WhitePawn8.Name = "WhitePawn8";
            WhitePawn8.Size = new Size(59, 57);
            WhitePawn8.SizeMode = PictureBoxSizeMode.CenterImage;
            WhitePawn8.TabIndex = 17;
            WhitePawn8.TabStop = false;
            WhitePawn8.Tag = "WP";
            WhitePawn8.Click += WhitePawn8_Click;
            // 
            // WhiteRook2
            // 
            WhiteRook2.BackColor = Color.Transparent;
            WhiteRook2.Image = (Image)resources.GetObject("WhiteRook2.Image");
            WhiteRook2.Location = new Point(458, 458);
            WhiteRook2.Name = "WhiteRook2";
            WhiteRook2.Size = new Size(59, 57);
            WhiteRook2.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteRook2.TabIndex = 19;
            WhiteRook2.TabStop = false;
            WhiteRook2.Tag = "WR";
            WhiteRook2.Click += WhiteRook2_Click;
            // 
            // WhiteKing
            // 
            WhiteKing.BackColor = Color.Transparent;
            WhiteKing.Image = (Image)resources.GetObject("WhiteKing.Image");
            WhiteKing.Location = new Point(263, 458);
            WhiteKing.Name = "WhiteKing";
            WhiteKing.Size = new Size(59, 57);
            WhiteKing.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteKing.TabIndex = 24;
            WhiteKing.TabStop = false;
            WhiteKing.Tag = "WK";
            WhiteKing.Click += WhiteKing_Click;
            // 
            // WhiteRook1
            // 
            WhiteRook1.BackColor = Color.Transparent;
            WhiteRook1.Image = (Image)resources.GetObject("WhiteRook1.Image");
            WhiteRook1.Location = new Point(3, 458);
            WhiteRook1.Name = "WhiteRook1";
            WhiteRook1.Size = new Size(59, 57);
            WhiteRook1.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteRook1.TabIndex = 18;
            WhiteRook1.TabStop = false;
            WhiteRook1.Tag = "WR";
            WhiteRook1.Click += WhiteRook1_Click;
            // 
            // WhiteQueen
            // 
            WhiteQueen.BackColor = Color.Transparent;
            WhiteQueen.Image = (Image)resources.GetObject("WhiteQueen.Image");
            WhiteQueen.Location = new Point(198, 458);
            WhiteQueen.Name = "WhiteQueen";
            WhiteQueen.Size = new Size(59, 57);
            WhiteQueen.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteQueen.TabIndex = 25;
            WhiteQueen.TabStop = false;
            WhiteQueen.Tag = "WQ";
            WhiteQueen.Click += WhiteQueen_Click;
            // 
            // BlackPawn1
            // 
            BlackPawn1.BackColor = Color.Transparent;
            BlackPawn1.Image = (Image)resources.GetObject("BlackPawn1.Image");
            BlackPawn1.Location = new Point(3, 68);
            BlackPawn1.Name = "BlackPawn1";
            BlackPawn1.Size = new Size(59, 58);
            BlackPawn1.TabIndex = 26;
            BlackPawn1.TabStop = false;
            BlackPawn1.Tag = "BP";
            BlackPawn1.Click += BlackPawn1_Click;
            // 
            // BlackPawn3
            // 
            BlackPawn3.BackColor = Color.Transparent;
            BlackPawn3.Image = (Image)resources.GetObject("BlackPawn3.Image");
            BlackPawn3.Location = new Point(133, 68);
            BlackPawn3.Name = "BlackPawn3";
            BlackPawn3.Size = new Size(59, 58);
            BlackPawn3.TabIndex = 28;
            BlackPawn3.TabStop = false;
            BlackPawn3.Tag = "BP";
            BlackPawn3.Click += BlackPawn3_Click;
            // 
            // BlackPawn4
            // 
            BlackPawn4.BackColor = Color.Transparent;
            BlackPawn4.Image = (Image)resources.GetObject("BlackPawn4.Image");
            BlackPawn4.Location = new Point(198, 68);
            BlackPawn4.Name = "BlackPawn4";
            BlackPawn4.Size = new Size(59, 58);
            BlackPawn4.TabIndex = 29;
            BlackPawn4.TabStop = false;
            BlackPawn4.Tag = "BP";
            BlackPawn4.Click += BlackPawn4_Click;
            // 
            // BlackPawn6
            // 
            BlackPawn6.BackColor = Color.Transparent;
            BlackPawn6.Image = (Image)resources.GetObject("BlackPawn6.Image");
            BlackPawn6.Location = new Point(328, 68);
            BlackPawn6.Name = "BlackPawn6";
            BlackPawn6.Size = new Size(59, 58);
            BlackPawn6.TabIndex = 30;
            BlackPawn6.TabStop = false;
            BlackPawn6.Tag = "BP";
            BlackPawn6.Click += BlackPawn6_Click;
            // 
            // BlackPawn7
            // 
            BlackPawn7.BackColor = Color.Transparent;
            BlackPawn7.Image = (Image)resources.GetObject("BlackPawn7.Image");
            BlackPawn7.Location = new Point(393, 68);
            BlackPawn7.Name = "BlackPawn7";
            BlackPawn7.Size = new Size(59, 58);
            BlackPawn7.TabIndex = 31;
            BlackPawn7.TabStop = false;
            BlackPawn7.Tag = "BP";
            BlackPawn7.Click += BlackPawn7_Click;
            // 
            // BlackPawn8
            // 
            BlackPawn8.BackColor = Color.Transparent;
            BlackPawn8.Image = (Image)resources.GetObject("BlackPawn8.Image");
            BlackPawn8.Location = new Point(458, 68);
            BlackPawn8.Name = "BlackPawn8";
            BlackPawn8.Size = new Size(59, 58);
            BlackPawn8.TabIndex = 32;
            BlackPawn8.TabStop = false;
            BlackPawn8.Tag = "BP";
            BlackPawn8.Click += BlackPawn8_Click;
            // 
            // BlackRook1
            // 
            BlackRook1.BackColor = Color.Transparent;
            BlackRook1.Image = (Image)resources.GetObject("BlackRook1.Image");
            BlackRook1.Location = new Point(3, 3);
            BlackRook1.Name = "BlackRook1";
            BlackRook1.Size = new Size(59, 58);
            BlackRook1.TabIndex = 33;
            BlackRook1.TabStop = false;
            BlackRook1.Tag = "BR";
            BlackRook1.Click += BlackRook1_Click;
            // 
            // BlackBishop2
            // 
            BlackBishop2.BackColor = Color.Transparent;
            BlackBishop2.Image = (Image)resources.GetObject("BlackBishop2.Image");
            BlackBishop2.Location = new Point(328, 3);
            BlackBishop2.Name = "BlackBishop2";
            BlackBishop2.Size = new Size(59, 58);
            BlackBishop2.TabIndex = 35;
            BlackBishop2.TabStop = false;
            BlackBishop2.Tag = "BB";
            BlackBishop2.Click += BlackBishop2_Click;
            // 
            // BlackBishop1
            // 
            BlackBishop1.BackColor = Color.Transparent;
            BlackBishop1.Image = (Image)resources.GetObject("BlackBishop1.Image");
            BlackBishop1.Location = new Point(133, 3);
            BlackBishop1.Name = "BlackBishop1";
            BlackBishop1.Size = new Size(59, 58);
            BlackBishop1.TabIndex = 34;
            BlackBishop1.TabStop = false;
            BlackBishop1.Tag = "BB";
            BlackBishop1.Click += BlackBishop1_Click;
            // 
            // BlackKnight1
            // 
            BlackKnight1.BackColor = Color.Transparent;
            BlackKnight1.Image = (Image)resources.GetObject("BlackKnight1.Image");
            BlackKnight1.Location = new Point(68, 3);
            BlackKnight1.Name = "BlackKnight1";
            BlackKnight1.Size = new Size(59, 58);
            BlackKnight1.TabIndex = 36;
            BlackKnight1.TabStop = false;
            BlackKnight1.Tag = "BH";
            BlackKnight1.Click += BlackKnight1_Click;
            // 
            // BlackKnight2
            // 
            BlackKnight2.BackColor = Color.Transparent;
            BlackKnight2.Image = (Image)resources.GetObject("BlackKnight2.Image");
            BlackKnight2.Location = new Point(393, 3);
            BlackKnight2.Name = "BlackKnight2";
            BlackKnight2.Size = new Size(59, 58);
            BlackKnight2.TabIndex = 37;
            BlackKnight2.TabStop = false;
            BlackKnight2.Tag = "BH";
            BlackKnight2.Click += BlackKnight2_Click;
            // 
            // WhiteKnight2
            // 
            WhiteKnight2.BackColor = Color.Transparent;
            WhiteKnight2.Image = (Image)resources.GetObject("WhiteKnight2.Image");
            WhiteKnight2.Location = new Point(393, 458);
            WhiteKnight2.Name = "WhiteKnight2";
            WhiteKnight2.Size = new Size(59, 57);
            WhiteKnight2.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteKnight2.TabIndex = 22;
            WhiteKnight2.TabStop = false;
            WhiteKnight2.Tag = "WH";
            WhiteKnight2.Click += WhiteKnight2_Click;
            // 
            // WhiteBishop2
            // 
            WhiteBishop2.BackColor = Color.Transparent;
            WhiteBishop2.Image = (Image)resources.GetObject("WhiteBishop2.Image");
            WhiteBishop2.Location = new Point(328, 458);
            WhiteBishop2.Name = "WhiteBishop2";
            WhiteBishop2.Size = new Size(59, 57);
            WhiteBishop2.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteBishop2.TabIndex = 21;
            WhiteBishop2.TabStop = false;
            WhiteBishop2.Tag = "WB";
            WhiteBishop2.Click += WhiteBishop2_Click;
            // 
            // WhiteBishop1
            // 
            WhiteBishop1.BackColor = Color.Transparent;
            WhiteBishop1.Image = (Image)resources.GetObject("WhiteBishop1.Image");
            WhiteBishop1.Location = new Point(133, 458);
            WhiteBishop1.Name = "WhiteBishop1";
            WhiteBishop1.Size = new Size(59, 57);
            WhiteBishop1.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteBishop1.TabIndex = 20;
            WhiteBishop1.TabStop = false;
            WhiteBishop1.Tag = "WB";
            WhiteBishop1.Click += WhiteBishop1_Click;
            // 
            // WhiteKnight1
            // 
            WhiteKnight1.BackColor = Color.Transparent;
            WhiteKnight1.Image = (Image)resources.GetObject("WhiteKnight1.Image");
            WhiteKnight1.Location = new Point(68, 458);
            WhiteKnight1.Name = "WhiteKnight1";
            WhiteKnight1.Size = new Size(59, 57);
            WhiteKnight1.SizeMode = PictureBoxSizeMode.CenterImage;
            WhiteKnight1.TabIndex = 23;
            WhiteKnight1.TabStop = false;
            WhiteKnight1.Tag = "WH";
            WhiteKnight1.Click += WhiteKnight1_Click;
            // 
            // Tiles
            // 
            Tiles.ColorDepth = ColorDepth.Depth32Bit;
            Tiles.ImageStream = (ImageListStreamer)resources.GetObject("Tiles.ImageStream");
            Tiles.TransparentColor = Color.Transparent;
            Tiles.Images.SetKeyName(0, "png-transparent-chessboard-mathematics-board-game-chess-game-symmetry-black-thumbnail.png");
            // 
            // button1
            // 
            button1.Location = new Point(298, 572);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 10;
            button1.Text = "Aloita peli";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(298, 539);
            label1.Name = "label1";
            label1.Size = new Size(121, 30);
            label1.TabIndex = 40;
            label1.Text = "Checkmate";
            label1.Click += label1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "circle-48.png");
            imageList1.Images.SetKeyName(1, "circle-24 (1).png");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 638);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BlackKing).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackQueen).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackRook2).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn5).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn2).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn1).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn2).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn3).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn4).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn5).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn6).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn7).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhitePawn8).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteRook2).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteKing).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteRook1).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteQueen).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn1).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn3).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn4).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn6).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn7).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackPawn8).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackRook1).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackBishop2).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackBishop1).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackKnight1).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlackKnight2).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteKnight2).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteBishop2).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteBishop1).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhiteKnight1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private LinkLabel linkLabel1;
        private ImageList ChessPieces;
        private System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tableLayoutPanel1;
        private ImageList Tiles;
        private PictureBox WhitePawn1;
        private PictureBox WhitePawn2;
        private PictureBox WhitePawn3;
        private PictureBox WhiteRook1;
        private PictureBox WhitePawn4;
        private PictureBox WhitePawn5;
        private PictureBox WhitePawn6;
        private PictureBox WhitePawn7;
        private PictureBox WhitePawn8;
        private PictureBox WhiteKing;
        private PictureBox WhiteKnight1;
        private PictureBox WhiteBishop1;
        private PictureBox WhiteRook2;
        private PictureBox WhiteBishop2;
        private PictureBox WhiteKnight2;
        private PictureBox WhiteQueen;
        private PictureBox BlackPawn1;
        private PictureBox BlackPawn2;
        private PictureBox BlackPawn3;
        private PictureBox BlackPawn5;
        private PictureBox BlackPawn4;
        private PictureBox BlackPawn6;
        private PictureBox BlackPawn7;
        private PictureBox BlackPawn8;
        private PictureBox BlackRook1;
        private PictureBox BlackBishop1;
        private PictureBox BlackKing;
        private PictureBox BlackQueen;
        private PictureBox BlackRook2;
        private PictureBox BlackBishop2;
        private PictureBox BlackKnight1;
        private PictureBox BlackKnight2;
        private Button button1;
        private Label label1;
        private ImageList imageList1;
    }
}
