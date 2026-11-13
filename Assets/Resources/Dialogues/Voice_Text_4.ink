EXTERNAL nextSequence()
EXTERNAL selectBall()
EXTERNAL awayFromTV()
EXTERNAL goToEndingWinBingo(endingNumber)

Shit. That sounds bad. #SPEAKER:Steve #AUDIO:KNOCK_DOOR
Maybe I should have a look. #SPEAKER:Steve
Are you sure, Stephen? #SPEAKER:???
~awayFromTV()
But then I'll miss the rest of the game... #SPEAKER:???
    +[Continue playing.]
        ~selectBall()
        ~nextSequence()
        -> DONE
    +[Investigate Noises]
        I'll go check. #SPEAKER: Steve
        ~goToEndingWinBingo(1)
        -> DONE
-> DONE
-> END