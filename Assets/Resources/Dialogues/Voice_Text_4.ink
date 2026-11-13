EXTERNAL nextSequence()
EXTERNAL selectBall()
EXTERNAL awayFromTV()
EXTERNAL goToEndingWinBingo(endingNumber)
EXTERNAL playClipBingoBallSick()
EXTERNAL setStage(stage)

~selectBall()
~nextSequence()
~playClipBingoBallSick()
~setStage(4)
Shit. That sounds bad. #SPEAKER:Steve
Maybe I should have a look. #SPEAKER:Steve
Are you sure, Stephen? #SPEAKER:???
~awayFromTV()
But then I'll miss the rest of the game... #SPEAKER: Steve
    +[Continue playing.]
        -> DONE
    +[Investigate Noises]
        I'll go check. #SPEAKER: Steve
        ~goToEndingWinBingo(1)
				~setStage(6)
        -> DONE
-> END