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

        private readonly Timer timer = new Timer();
        private DataGridView dgv = null;
        private int rowIndex = 0;

        private bool mouseActive = false;
        private bool checkForMouseActive = false;

        internal WaitToLoadMenu()
        {
            timer.Interval = 200;
            timer.Tick += WaitOpen_Tick;
        }

        internal void MouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            timer.Stop();
            StopLoadMenu.Invoke();
            SetData((DataGridView)sender, e.RowIndex);
            checkForMouseActive = true;
            timer.Start();
        }

        internal void RowSelected(DataGridView dgv, int rowIndex)
        {
            timer.Stop();
            StopLoadMenu.Invoke();
            SetData(dgv, rowIndex);
            mouseActive = false;
            checkForMouseActive = false;
            timer.Start();
        }

        internal void MouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            timer.Stop();
            StopLoadMenu.Invoke();
            ResetData((DataGridView)sender, e.RowIndex);
        }

        internal void RowDeselected(int iMenuBefore, int rowIndex, DataGridView dgv) //iMenuBefore not needed
        {
            timer.Stop();
            StopLoadMenu.Invoke();
            ResetData(dgv, rowIndex);
            mouseActive = false;
        }

        internal void ClickOpensInstantly(DataGridView dgv, int rowIndex)
        {
            timer.Stop();
            StopLoadMenu.Invoke();
            SetData(dgv, rowIndex);
            mouseActive = true;
            checkForMouseActive = false;
            CallOpenMenuNow();
        }

        internal void EnterOpensInstantly(DataGridView dgv, int rowIndex)
        {
            timer.Stop();
            StopLoadMenu.Invoke();
            SetData(dgv, rowIndex);
            mouseActive = false;
            checkForMouseActive = false;
            CallOpenMenuNow();
        }

        internal void MouseMove(object sender, MouseEventArgs e)
        {
            mouseActive = true;
        }

        private void WaitOpen_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (!checkForMouseActive || mouseActive)
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
                    rowData.MenuLevel < MenuDefines.MenusMax)
                {
                    StartLoadMenu.Invoke(rowData);
                }
            }
        }

        private void SetData(DataGridView dgv, int rowIndex)
        {
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
            timer.Stop();
            timer.Dispose();
        }
    }
}