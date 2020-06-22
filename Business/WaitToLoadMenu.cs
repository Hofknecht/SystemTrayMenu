using System;
using System.Windows.Forms;
using SystemTrayMenu.DataClasses;
using SystemTrayMenu.UserInterface;
using SystemTrayMenu.Utilities;
using Timer = System.Windows.Forms.Timer;

namespace SystemTrayMenu.Handler
{
    internal class WaitToLoadMenu : IDisposable
    {
        internal event Action<RowData> StartLoadMenu;
        internal event EventHandlerEmpty StopLoadMenu;
        internal event Action<DataGridView, int> MouseEnterOk;

        private readonly Timer timerStartLoad = new Timer();
        private DataGridView dgv = null;
        private int rowIndex = 0;
        private DataGridView dgvTmp = null;
        private int rowIndexTmp = 0;

        internal bool MouseActive = false;
        private int mouseMoveEvents = 0;
        private DateTime dateTimeLastMouseMoveEvent = DateTime.Now;
        private bool checkForMouseActive = true;

        internal WaitToLoadMenu()
        {
            timerStartLoad.Interval = 200;
            timerStartLoad.Tick += WaitStartLoad_Tick;
        }

        internal void MouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (MouseActive)
            {
                DataGridView dgv = (DataGridView)sender;
                MouseEnterOk(dgv, e.RowIndex);
                timerStartLoad.Stop();
                StopLoadMenu.Invoke();
                checkForMouseActive = true;
                SetData(dgv, e.RowIndex);
                timerStartLoad.Start();
            }
            else
            {
                this.dgvTmp = (DataGridView)sender;
                this.rowIndexTmp = e.RowIndex;
            }
        }

        internal void RowSelected(DataGridView dgv, int rowIndex)
        {
            timerStartLoad.Stop();
            StopLoadMenu.Invoke();
            SetData(dgv, rowIndex);
            MouseActive = false;
            checkForMouseActive = false;
            timerStartLoad.Start();
        }

        internal void MouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (MouseActive)
            {
                timerStartLoad.Stop();
                StopLoadMenu.Invoke();
                ResetData((DataGridView)sender, e.RowIndex);
            }
        }

        internal void RowDeselected(int iMenuBefore, int rowIndex, DataGridView dgv) //iMenuBefore not needed
        {
            timerStartLoad.Stop();
            StopLoadMenu.Invoke();
            ResetData(dgv, rowIndex);
            MouseActive = false;
        }

        internal void ClickOpensInstantly(DataGridView dgv, int rowIndex)
        {
            timerStartLoad.Stop();
            StopLoadMenu.Invoke();
            SetData(dgv, rowIndex);
            MouseActive = true;
            checkForMouseActive = false;
            CallOpenMenuNow();
        }

        internal void EnterOpensInstantly(DataGridView dgv, int rowIndex)
        {
            if (dgv.Rows.Count > rowIndex)
            {
                timerStartLoad.Stop();
                StopLoadMenu.Invoke();
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
                if (mouseMoveEvents > 3)
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
                rowData.MenuLevel = menu.Level;
                if (!rowData.IsContextMenuOpen &&
                    rowData.ContainsMenu &&
                    rowData.MenuLevel + 1 < MenuDefines.MenusMax)
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
            rowData.IsSelected = true;
            dgv.Rows[rowIndex].Selected = true;
        }

        private void ResetData(DataGridView dgv, int rowIndex)
        {
            if (dgv != null)
            {
                RowData rowData = (RowData)dgv.Rows[rowIndex].Cells[2].Value;
                rowData.IsSelected = false;
                dgv.Rows[rowIndex].Selected = false;
                this.dgv = null;
                this.rowIndex = 0;
            }
        }

        public void Dispose()
        {
            timerStartLoad.Stop();
            timerStartLoad.Dispose();
            dgv.Dispose();
            dgvTmp.Dispose();
        }
    }
}