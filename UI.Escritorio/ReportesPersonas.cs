﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Escritorio
{
    public partial class ReportesPersonas : Form
    {
        public ReportesPersonas()
        {
            InitializeComponent();
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"D:\Usuario\TP2_Net\UI.Escritorio\crPersonas.rpt");

            crConnectionInfo.ServerName = "Casa";
            crConnectionInfo.DatabaseName = "tp2_net";
            crConnectionInfo.UserID = "net";
            crConnectionInfo.Password = "net";

            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer2.ReportSource = cryRpt;
            crystalReportViewer2.RefreshReport();
        }
    }
}
