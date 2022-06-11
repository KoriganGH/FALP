open System
open System.Drawing
open System.Windows.Forms

let form = new Form(Width= 256, Height = 266, Visible = true, Text = "ЛР7", BackColor = System.Drawing.Color.DarkGray)
let textBox1 = new TextBox(Location = new Point(48, 23) ,Name = "textBox1", Size = new Size(59, 23))
let label1 = new Label(AutoSize = true, Location = new Point(31, 23), Name = "label1", Size = new Size(15, 15), Text = "A")
let textBox2 = new TextBox( Location = new Point(128, 23), Name = "textBox2", Size = new Size(59, 23))       
let label2 = new Label(AutoSize = true, Location = new Point(192, 23), Name = "label2", Size = new Size(15, 15), Text = "B")                     
let textBox3 = new TextBox(Location = new Point(48, 81), Name = "textBox3", Size = new Size(139, 23))
let label3 = new Label(AutoSize = true, Location = new Point(112, 60), Name = "label3", Size = new Size(15, 15), Text = "S")  
let button1 = new Button(Location = new Point(75, 122), Name = "button1", Size = new Size(78, 78), Text = "Кнопка", BackColor = System.Drawing.Color.Gray)

form.Controls.Add(button1)
form.Controls.Add(textBox1)
form.Controls.Add(label1)
form.Controls.Add(label2)
form.Controls.Add(textBox2)
form.Controls.Add(label3)
form.Controls.Add(textBox3)

let m _ =
    if (textBox1.Text > "0" && textBox2.Text > "0" &&
        textBox1.Text < "999999999" && textBox2.Text < "999999999")
    then
        let A = float textBox1.Text
        let B = float textBox2.Text
        let S = A * B
        textBox3.Text <- string S
    else MessageBox.Show("Введите корректные значения", "Сообщение") |> ignore

button1.Click.Add(m)

[<EntryPoint>]
let main argv =
    do Application.Run(form)
    0 
            