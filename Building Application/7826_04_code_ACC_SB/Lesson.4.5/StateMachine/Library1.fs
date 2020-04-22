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

