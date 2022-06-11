(*список квадратов элементов*)

open System
open System.Drawing
open System.Windows.Forms
open System
open System.Drawing
open System.Windows.Forms

let form = new Form(Width= 330, Height = 200, Text = "ЛР9", BackColor = System.Drawing.Color.DarkGray)
let button1 = new Button(Location = new Point(208, 43), Name = "button1", Size = new Size(98, 68), Text = "Кнопка", BackColor = System.Drawing.Color.Gray)
let textBox1 = new TextBox(Location = new Point(4, 44) ,Name = "textBox1", Size = new Size(198, 23))
let label1 = new Label(AutoSize = true, Location = new Point(4, 26), Name = "label1", Size = new Size(15, 15), Text = "Ввод")          
let label2 = new Label(AutoSize = true, Location = new Point(4, 70), Name = "label3", Size = new Size(15, 15), Text = "Вывод")           
let textBox2 = new TextBox(Location = new Point(4, 91), Name = "textBox3", Size = new Size(198, 23))

form.Controls.Add(button1)
form.Controls.Add(textBox1)
form.Controls.Add(label1)
form.Controls.Add(label2)
form.Controls.Add(textBox2)

let m _ =
    let input = textBox1.Text
    let input_l = input.Split(' ')
    let square = Seq.fold (fun s x -> s + string (Math.Pow(int x, 2)) + " ") "" input_l
    textBox2.Text <- square

  
button1.Click.Add(m)

[<EntryPoint>]
let main argv =
    do Application.Run(form)
    0 
