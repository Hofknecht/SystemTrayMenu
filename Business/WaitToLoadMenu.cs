// <copyright file="WaitToLoadMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Windows.Forms;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;
    using Timer = System.Windows.Forms.Timer;

    internal class WaitToLoadMenu : IDisposable
    {
        private readonly Timer timerStartLoad = new();
        private DataGridView dgv;
        private int rowIndex;
        private DataGridView dgvTmp;
        private int rowIndexTmp;

        private int mouseMoveEvents;
        private DateTime dateTimeLastMouseMoveEvent = DateTime.Now;
        private bool checkForMouseActive = true;

        internal WaitToLoadMenu()
        {
            timerStartLoad.Interval = Properties.Settings.Default.TimeUntilOpens;
            timerStartLoad.Tick += WaitStartLoad_Tick;
        }

        internal event Action<RowData> StartLoadMenu;

        internal event Action<int> CloseMenu;

        internal event Action StopLoadMenu;

        internal event Action<DataGridView, int> MouseEnterOk;

        internal bool MouseActive { get; set; }

        public void Dispose()
        {
            timerStartLoad.Tick -= WaitStartLoad_Tick;
            timerStartLoad.Stop();
            timerStartLoad.Dispose();
            dgv?.Dispose();
            dgvTmp?.Dispose();
        }

        internal void MouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (MouseActive)
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Rows.Count > e.RowIndex)
                {
                    MouseEnterOk(dgv, e.RowIndex);
                    timerStartLoad.Stop();
                    StopLoadMenu?.Invoke();
                    checkForMouseActive = true;
                    SetData(dgv, e.RowIndex);
                    timerStartLoad.Start();
                }
            }
            else
            {
                dgvTmp = (DataGridView)sender;
                rowIndexTmp = e.RowIndex;
            }
        }

        internal void RowSelected(DataGridView dgv, int rowIndex)
        {
            if (dgv.Rows.Count > rowIndex)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                SetData(dgv, rowIndex);
                MouseActive = false;
                checkForMouseActive = false;
                timerStartLoad.Start();
            }
        }

        internal void MouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (MouseActive)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                ResetData((DataGridView)sender, e.RowIndex);
            }
        }

        internal void RowDeselected(DataGridView dgv, int rowIndex)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            ResetData(dgv, rowIndex);
            MouseActive = false;
        }

        internal void ClickOpensInstantly(DataGridView dgv, int rowIndex)
        {
            if (dgv.Rows.Count > rowIndex)
            {
                timerStartLoad.Stop();
                SetData(dgv, rowIndex);
                MouseActive = true;
                checkForMouseActive = false;
                CallOpenMenuNow();
            }
        }

        internal void EnterOpensInstantly(DataGridView dgv, int rowIndex)
        {
            if (dgv.Rows.Count > rowIndex)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                SetData(dgv, rowIndex);
                MouseActive = false;
                checkForMouseActive = false;
                CallOpenMenuNow();
            }
        }

        internal void MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseActive)
            {
                if (mouseMoveEvents > 6)
                {
                    MouseActive = true;
                    if (dgvTmp != null && !dgvTmp.IsDisposed)
                    {
                        MouseEnter(dgvTmp, new DataGridViewCellEventArgs(
                            0, rowIndexTmp));
                    }

                    mouseMoveEvents = 0;
                }
                else if (DateTime.Now - dateTimeLastMouseMoveEvent <
                    new TimeSpan(0, 0, 0, 0, 200))
                {
                    mouseMoveEvents++;
                }
                else
                {
                    dateTimeLastMouseMoveEvent = DateTime.Now;
                    mouseMoveEvents = 0;
                }
            }
        }

        private void WaitStartLoad_Tick(object sender, EventArgs e)
        {
            timerStartLoad.Stop();
            if (!checkForMouseActive || MouseActive)
            {
                CallOpenMenuNow();
            }
        }

        private void CallOpenMenuNow()
        {
            if (dgv.Rows.Count > rowIndex)
            {
                RowData rowData = (RowData)dgv.Rows[rowIndex].Cells[2].Value;
                Menu menu = (Menu)dgv.FindForm();
                rowData.Level = menu.Level;
                if (rowData.ContainsMenu)
                {
                    CloseMenu.Invoke(rowData.Level + 2);
                }

                CloseMenu.Invoke(rowData.Level + 1);

                if (!rowData.IsContextMenuOpen &&
                    rowData.ContainsMenu &&
                    rowData.Level + 1 < MenuDefines.MenusMax)
                {
                    StartLoadMenu.Invoke(rowData);
                }
            }
        }

        private void SetData(DataGridView dgv, int rowIndex)
        {
            dgvTmp = null;
            this.dgv = dgv;
            this.rowIndex = rowIndex;
            RowData rowData = (RowData)dgv.Rows[rowIndex].Cells[2].Value;
            if (rowData != null)
            {
                rowData.IsSelected = true;
            }

            dgv.Rows[rowIndex].Selected = false;
            dgv.Rows[rowIndex].Selected = true;
        }

        private void ResetData(DataGridView dgv, int rowIndex)
        {
            if (dgv != null && dgv.Rows.Count > rowIndex)
            {
                RowData rowData = (RowData)dgv.Rows[rowIndex].Cells[2].Value;
                if (rowData != null)
                {
                    rowData.IsSelected = false;
                    rowData.IsClicking = false;
                    dgv.Rows[rowIndex].Selected = false;
                    this.dgv = null;
                    this.rowIndex = 0;
                }
            }
        }
    }
}