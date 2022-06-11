(* Разработать программу, состоящую из главной формы
на которой размещены два флажка и одна кнопка. По нажатию
на кнопку появляется сообщение «установлен первый флажок»,
«установлен второй флажок», «установлены оба флажка». *)

open System 
open System.Windows.Forms
open System.Drawing 
open System.IO

let Form = new Form(Width = 340, Height = 100, Text = "ЛР5", BackColor = System.Drawing.Color.DarkSlateBlue)

let checkBox1 = new CheckBox(AutoSize = true, Location = new Point(16, 16), Name = "checkBox1")
Form.Controls.Add(checkBox1)

let checkBox2 = new CheckBox(AutoSize = true, Location = new Point(16, 34), Name = "checkBox2")
Form.Controls.Add(checkBox2)

let button1 = new Button(AutoSize = true, Location = new Point(48, 16), Name = "button1", Size = new Size(250, 32), Text = "Кнопка", BackColor = System.Drawing.Color.DarkGray)
Form.Controls.Add(button1)

let message _ = 
    let x = (checkBox1.Checked,checkBox2.Checked)
    match x with
    |(true,false) -> MessageBox.Show("Установлен первый флажок", "Сообщение") |> ignore
    |(false,true) -> MessageBox.Show("Установлен второй флажок", "Сообщение") |> ignore
    |(true,true) -> MessageBox.Show("Установлены оба флажка", "Сообщение") |> ignore
    |(false,false) -> MessageBox.Show("Ни один из флажков не установлен", "Сообщение") |> ignore
let _= button1.Click.Add(message)

[<EntryPoint>]
let main argv =
    do Application.Run(Form)
    0 