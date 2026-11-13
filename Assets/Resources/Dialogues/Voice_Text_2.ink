EXTERNAL nextSequence()
EXTERNAL selectBall()
EXTERNAL playRandomClipBingoBall()
EXTERNAL setStage(stage)
EXTERNAL goToEndingWinBingo(endingNumber)
EXTERNAL awayFromTV()

(stares at screen) #SPEAKER: Steve
    +[Play next number.]
        Gah! I can't watch. But I HAVE to see what the next number is. #SPEAKER: Steve
		~selectBall()
		~nextSequence()
		~playRandomClipBingoBall()
		~setStage(2)
		Another match! #SPEAKER: Steve
		Maybe I'll start believing in lucky numbers after all. #SPEAKER: Steve
		(kisses ticket) #SPEAKER: Steve
		OW! #SPEAKER: Steve
		Fucking stop zapping me! #SPEAKER: Steve
		-> DONE
    +[Turn off TV.]
	    ~awayFromTV()
	    This is a waste of time. I'm not playing this. #SPEAKER: Steve
	    One number right, that's gotta be worth something? #SPEAKER: Steve
	    Maybe I can still find a sucker to sell it to... #SPEAKER: Steve
	    ~goToEndingWinBingo(2)
	    ~setStage(6)
	    -> DONE
-> END