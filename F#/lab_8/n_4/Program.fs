open System

let printerAgent = MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async{
        let! msg = inbox.Receive()
        match msg with
        | "F#" -> printfn "%s"("Ты подлиза!")
        | "Prolog" -> printfn "%s"("Ты подлиза!")
        | _ -> printfn "%s"("Все понятно..")
        return! messageLoop()
        }
    messageLoop()
    )

[<EntryPoint>]
let main argv =
    printerAgent.Post("F#")
    printerAgent.Post("Prolog")
    printerAgent.Post("Python")
    Console.ReadKey() |> ignore
    0 