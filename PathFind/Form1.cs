using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFind
{
    public partial class Form1 : Form
    {
        Color PathColor = Color.Yellow;
        Color WallColor = Color.Red;
        Color PointerColor = Color.Blue;
        Color GridColor = Color.Black;

        int row = 0, col = 0;
        int pictureBoxWith = 0, pictureBoxHeight = 0;
        int cellWidth = 0, cellHeight = 0;
        Dictionary<Cell, bool> walls;
        Point pointerLocation;
        Cell startLocation;
        Cell endLocation;
        List<Cell> path;


        private void timer1_Tick(object sender, EventArgs e)
        {
            pointerLocation = pictureBox1.PointToClient(System.Windows.Forms.Cursor.Position);
            pointLocation.Text = pointerLocation.ToString();
            path = GetPath(startLocation, endLocation, diagonalCheckBox.Checked);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawGridLines(e.Graphics, row, col);
            DrawWalls(e.Graphics);
            DrawStartCell(e.Graphics);
            if (!createWallRadio.Checked)
            { 
                DrawPath(e.Graphics, path);
            }
            //else
            
                DrawPointedCell(e.Graphics);
            
        }

        public Form1()
        {
            InitializeComponent();
            row = 20;
            col = 20;
            pictureBoxWith = pictureBox1.Width;
            pictureBoxHeight = pictureBox1.Height;
            cellWidth = pictureBoxWith / col;
            cellHeight = pictureBoxHeight / row;
            walls = new Dictionary<Cell, bool>();
            timer1.Start();            
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (createWallRadio.Checked)
            {
                if (!AddWall(pointerLocation))
                    RemoveWall(pointerLocation);

            }
            else if (findPathRadio.Checked)
            {
                if (startLocation == null)
                    startLocation = new Cell();
                startLocation.Row = pointerLocation.Y / cellHeight;
                startLocation.Col = pointerLocation.X / cellWidth;
            }
        }

        private void DrawGridLines(Graphics graphics, int row, int col)
        {
            int width = pictureBoxWith / col;
            int height = pictureBoxHeight / row;
            Pen gridPen = new Pen(GridColor, 2);
            Point start = new Point();
            Point end = new Point();
            for (int i = 0; i < row; i++)
            {
                start.X = 0;
                start.Y += height;
                end.X = pictureBoxWith;
                end.Y += height;
                graphics.DrawLine(gridPen, start, end);
            }
            start = new Point();
            end = new Point();
            for (int i = 0; i < col; i++)
            {
                start.X += width;
                start.Y = 0;
                end.X += width;
                end.Y = pictureBoxHeight;
                graphics.DrawLine(gridPen, start, end);
            }
        }

        private void DrawPointedCell(Graphics graphics)
        {
            int rowLoc = pointerLocation.Y / cellHeight;
            int colLoc = pointerLocation.X / cellWidth;
            if (endLocation == null)
                endLocation = new Cell();
            endLocation.Row = rowLoc;
            endLocation.Col = colLoc;
            if (!IsOutOfBounds(rowLoc, colLoc))
            {
                SolidBrush brush = new SolidBrush(this.PointerColor);
                Rectangle rect = new Rectangle();
                rect.Y = rowLoc * cellHeight;
                rect.X = colLoc * cellWidth;
                rect.Width = cellWidth;
                rect.Height = cellHeight;
                graphics.FillRectangle(brush, rect);
            }
        }

        private void DrawWalls(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(WallColor);
            Rectangle rect = new Rectangle();
            rect.Width = cellWidth;
            rect.Height = cellHeight;
            foreach (Cell key in walls.Keys)
            {
                rect.Y = key.Row * cellHeight;
                rect.X = key.Col * cellWidth;
                graphics.FillRectangle(brush, rect);
            }
        }

        private void DrawStartCell(Graphics graphics)
        {
            if(startLocation != null)
            { 
                SolidBrush brush = new SolidBrush(PathColor);
                Rectangle rect = new Rectangle();
                rect.Width = cellWidth;
                rect.Height = cellHeight;
                rect.Y = startLocation.Row * cellHeight;
                rect.X = startLocation.Col * cellWidth;
                graphics.FillRectangle(brush, rect);
            }
        }

        private void DrawPath(Graphics graphics, List<Cell> list)
        {
            if (path == null)
                return;
            
            SolidBrush brush = new SolidBrush(PathColor);
            Rectangle rect = new Rectangle();
            rect.Width = cellWidth;
            rect.Height = cellHeight;
            foreach (Cell cell in list)
            {
                rect.Y = cell.Row * cellHeight;
                rect.X = cell.Col * cellWidth;
                graphics.FillRectangle(brush, rect);
            }
        }

        private bool AddWall(Point pointer)
        {
            Cell cell = new Cell();
            cell.Row = pointer.Y / cellHeight;
            cell.Col = pointer.X / cellWidth;
            if (walls.ContainsKey(cell))
                return false;
            walls[cell] = true;
            return true;
        }
        private bool RemoveWall(Point pointer)
        {
            Cell cell = new Cell();
            cell.Row = pointer.Y / cellHeight;
            cell.Col = pointer.X / cellWidth;
            
            if (walls.ContainsKey(cell))
            { 
                walls.Remove(cell);
                return true;
            }
            return false;
        }

        private List<Cell> GetPath(Cell start, Cell end, bool diagonal = false)
        {
            if (start == null)
                return null;
            if (walls.ContainsKey(end))
                return null;
            Queue<Cell> queue = new Queue<Cell>();
            Dictionary<Cell, Cell> visited = new Dictionary<Cell, Cell>();
            queue.Enqueue(start);
            bool found = false;
            Cell currentCell = null;
            while (!found && queue.Count > 0)
            {
                currentCell = queue.Dequeue();
                List<Cell> adjacent = (diagonal)?currentCell.AdjacentWithDiagonal: currentCell.Adjacent;
                foreach (Cell cell in adjacent)
                {
                    if (visited.ContainsKey(cell))
                        continue;
                    if (walls.ContainsKey(cell))
                        continue;
                    if (IsOutOfBounds(cell.Row, cell.Col))
                        continue;
                    visited[cell] = currentCell;
                    if (cell.Equals(end))
                    {
                        found = true;
                        break;
                    }                    
                    queue.Enqueue(cell);
                }
            }
            if(found)
            {
                List<Cell> path = new List<Cell>();
                Cell current = end;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    current = visited[current];
                }
                return path.ToList();
            }
            return null;
        }

        private bool IsOutOfBounds(int rowLoc, int colLoc)
        {
            return !(rowLoc < this.row &&
                rowLoc >= 0 &&
                colLoc < this.col &&
                colLoc >= 0);
        }

        class Cell
        {
            public Cell() { }
            public Cell(int row, int col)
            {
                Row = row;
                Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }
            public Cell Left {
                get {
                    return new Cell(Row - 1, Col);
                }
            }
            public Cell Right
            {
                get
                {
                    return new Cell(Row + 1, Col);
                }
            }
            public Cell Top
            {
                get
                {
                    return new Cell(Row , Col - 1);
                }
            }
            public Cell Bottom
            {
                get
                {
                    return new Cell(Row , Col + 1);
                }
            }
            public Cell TopLeft
            {
                get
                {
                    return new Cell(Row - 1, Col - 1);
                }
            }
            public Cell TopRight
            {
                get
                {
                    return new Cell(Row - 1, Col + 1);
                }
            }
            public Cell BottomLeft
            {
                get
                {
                    return new Cell(Row + 1, Col - 1);
                }
            }
            public Cell BottomRight
            {
                get
                {
                    return new Cell(Row + 1, Col + 1);
                }
            }
            public List<Cell> Adjacent {
                get
                {
                    List<Cell> list = new List<Cell>();
                    list.Add(Left);
                    list.Add(Right);
                    list.Add(Top);
                    list.Add(Bottom);
                    return list;
                }
            }
            public List<Cell> AdjacentWithDiagonal
            {
                get
                {
                    List<Cell> list = Adjacent;
                    list.Add(TopLeft);
                    list.Add(TopRight);
                    list.Add(BottomLeft);
                    list.Add(BottomRight);
                    return list;
                }
            }

            public override bool Equals(Object obj)
            {
                if (obj is Cell)
                {
                    Cell temp = (Cell)obj;
                    return temp.Row == Row && temp.Col == Col;
                }
                return false;
            }

            public override int GetHashCode()
            {
                var hashCode = 1084646500;
                hashCode = hashCode * -1521134295 + Row.GetHashCode();
                hashCode = hashCode * -1521134295 + Col.GetHashCode();
                return hashCode;
            }
        }
    }
}
