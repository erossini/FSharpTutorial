module StateMachine

    module Automobile =

        type AutomobileState =
            | NotRunning
            | Idling
            | Moving

        type AutomobileEvent =
            | Ignition
            | PutInDrive
            | TurnLeft
            | TurnRight
            | Stop
            | TurnOff

        let stateMachine (state, event) =
            match state, event with
            | NotRunning, Ignition
                ->  Idling
            | Idling, PutInDrive
                ->  Moving
            | Moving, TurnLeft
                ->  Moving
            | Moving, TurnRight
                ->  Moving
            | Moving, Stop
                ->  Idling
            | Idling, TurnOff
                ->  NotRunning
            | _
                ->  failwith "Invalid state transition"

        let private stateTransitions event =
            match event with
            | Ignition
                ->  Idling
            | PutInDrive
                ->  Moving
            | TurnLeft
                ->  Moving
            | TurnRight
                ->  Moving
            | Stop
                ->  Idling
            | TurnOff
                ->  NotRunning

        let private getEventsForState state =
            match state with
            | NotRunning
                ->  [| Ignition |]
            | Idling
                ->  [| PutInDrive; TurnOff |]
            | Moving
                ->  [| TurnLeft; TurnRight; Stop |]

        type AllowedEvent = 
            {
                EventInfo : AutomobileEvent
                RaiseEvent : unit -> EventResult
            }
        and EventResult =
            {
                CurrentState : AutomobileState
                AllowedEvents : AllowedEvent array
            }
                  
        let rec private stateMachine event =
            let newState = stateTransitions event
            let newEvents = getEventsForState newState
            {
                CurrentState = newState
                AllowedEvents =
                    newEvents
                    |> Array.map (fun e -> 
                        let f() = stateMachine e
                        {
                            EventInfo = e
                            RaiseEvent = f
                        } )
             }

        let init() = stateMachine TurnOff

        let foo = init()
        let foo1 = foo.AllowedEvents.[0].Event()
        let foo2 = foo1.AllowedEvents.[0].Event()
        let foo3 = foo2.AllowedEvents.[2].Event()
        let foo4 = foo3.AllowedEvents.[1].Event()
