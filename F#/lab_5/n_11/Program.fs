open System

let question m =
  match m with
   |"F#"->printf "Ты подлиза!"
   |"Prolog"->printf "Ты подлиза!"
   |_->printf "Все понятно.."
   
[<EntryPoint>]
let main argv =
    printfn "Какой твой любимый язык программирования?"
    let m = System.Console.ReadLine();
    question m
    0
