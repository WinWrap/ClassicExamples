Sub Main
	Dim T As Single, L As Long
	Do
		L = 0
		T = Timer+5
		While Timer < T
			L = L + 1
		Wend
		Debug.Print L
		Beep
	Loop
End Sub
