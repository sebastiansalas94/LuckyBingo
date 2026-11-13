EXTERNAL nextSequence()
EXTERNAL selectBall()
EXTERNAL goToEndingWinBingo(endingNumber)

Just one more, Stephen. #SPEAKER: ???
Just one more... #SPEAKER: Steve
    +[Play the game.]
        ~selectBall()
        ~nextSequence()
        I got the last number! I can't believe it! #SPEAKER:Steve
        I gotta call my ma. #SPEAKER:Steve
        No, wait. #SPEAKER:Steve
        First I'll call the landlord and tell him exactly where to stick it! #SPEAKER:Steve
        HEAR THAT FRANK? #SPEAKER:Steve
        ~goToEndingWinBingo(0)
        -> DONE
    +[I've changed my mind.]
        I'll go check. #SPEAKER: Steve
        ~goToEndingWinBingo(1)
        -> DONE
-> END