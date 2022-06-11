(*пересечение множеств*)

open System
open System.Drawing
open System.Windows.Forms

let form = new Form(Width= 350, Height = 160, Text = "ЛР8", BackColor = System.Drawing.Color.DarkGray)
let textBox1 = new TextBox(Location = new Point(48, 23) ,Name = "textBox1", Size = new Size(198, 23))
let label1 = new Label(AutoSize = true, Location = new Point(31, 26), Name = "label1", Size = new Size(17, 15), Text = "A")
let label2 = new Label(AutoSize = true, Location = new Point(31, 55), Name = "label2", Size = new Size(17, 15), Text = "B")           
let textBox2 = new TextBox( Location = new Point(48, 52), Name = "textBox2", Size = new Size(198, 23))       
let label3 = new Label(AutoSize = true, Location = new Point(20, 84), Name = "label3", Size = new Size(38, 15), Text = "A∩B")        
let textBox3 = new TextBox(Location = new Point(48, 81), Name = "textBox3", Size = new Size(198, 23))
let button1 = new Button(Location = new Point(252, 23), Name = "button1", Size = new Size(76, 81), Text = "Кнопка", BackColor = System.Drawing.Color.Gray)

form.Controls.Add(button1)
form.Controls.Add(textBox1)
form.Controls.Add(label1)
form.Controls.Add(label2)
form.Controls.Add(textBox2)
form.Controls.Add(label3)
form.Controls.Add(textBox3)

let intersection (arr1: string array) (arr2: string array) = 
    let c = 0
    Array.append (Array.fold (fun acc elem1 -> if (Array.tryFind (fun y -> y = elem1) arr2) = None then (Array.append acc [||]) else Array.append acc [|elem1|])
    [||] arr1) (Array.fold (fun acc elem2 -> if (Array.tryFind (fun y -> y = elem2) arr1) = None then (Array.append acc [||]) else Array.append acc [|elem2|]) [||] arr2) 

let m _ =
    let A = (textBox1.Text).Split( [|','|])
    let B = (textBox2.Text).Split( [|','|])
    let rec ArrayToString (arr:string []) i acc:string =
            if (i = arr.Length/2) then acc
            else ArrayToString arr (i+1) (acc + "," + arr.[i])
    let result = intersection A B
    let output = (ArrayToString result 0 "")
    textBox3.Text <- output.[1..]

button1.Click.Add(m)

[<EntryPoint>]
let main argv =
    do Application.Run(form)
    0 