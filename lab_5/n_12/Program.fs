open System

let question (m:string) = 
  match m with
   |"F#"->printf "Ты подлиза!"
   |"Prolog"->printf "Ты подлиза!"
   |_->printf "Все понятно..."
   
[<EntryPoint>]
let main argv =
    //1
    printfn "Какой твой любимый язык программирования?"
    (Console.ReadLine >> question >> Console.WriteLine)()
    //2
    printfn "Какой твой любимый язык программирования?"
    Console.WriteLine(question(Console.ReadLine()))
    0 