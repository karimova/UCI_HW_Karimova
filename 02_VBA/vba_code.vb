Sub ticker():

Dim ticker As String

Dim rows, count, tick_num As Long

Dim year, percent, totalStock As Double

Dim percentMax, percentMin, totalStockMax As Double

Dim ws As Worksheet

Dim i, j, m, n As Integer


'Loop througth All Sheets in the WorkBook

For Each ws In Worksheets

    'Activating the Sheet
    ws.Activate
    
    'to find the last populated cell in a particular column - to know how many lines in the sheet
    rows = ws.Cells(ws.Cells.rows.count, 1).End(xlUp).Row
    'ws.Cells(1, 8).Value = rows
    
    ws.Cells(1, 10).Value = "Ticker"
    ws.Cells(1, 11).Value = "Yearly Change"
    ws.Cells(1, 12).Value = "Percent Change"
    ws.Cells(1, 13).Value = "Total Stock Volume"

    ws.Cells(2, 16).Value = "Greatest % Increase"
    ws.Cells(3, 16).Value = "Greatest % Decrease"
    ws.Cells(4, 16).Value = "Greates Total Volume"

    ws.Cells(1, 17).Value = "Ticker"
    ws.Cells(1, 18).Value = "Value"

    '------------------------------
    'Part-I
    '------------------------------
    'Calculating data - Tickers/Yearly Changes/Percent Change/Total Stock Volume
    tick_num = 0
    count = 0
    For i = 2 To rows
        tick_num = tick_num + 1 'to count # of tickers per category
        
        If ws.Cells(i + 1, 1).Value <> ws.Cells(i, 1).Value Then
        
            count = count + 1 'count when ticker changes name

            '---------------TICKER--------------------
            'return the symbol of Ticker to the F column (gives us the column of all types of tickers)
            ws.Cells(1 + count, 10).Value = ws.Cells(i, 1).Value
        
            'numbers tickers per category
            'ws.Cells(1 + count, 15).Value = tick_num

            '---------------TOTAL STOCK VOLUME--------------------
            'Total Stock Volume - SUM function for the Range
            totalStock = Application.Sum(Range(ws.Cells(i - tick_num + 1, 7), ws.Cells(i, 7)))
            ws.Cells(1 + count, 13).Value = totalStock
        
            '---------------PERCENT CHANGE--------------------
            'Some table data for "opening price in column C" and "closing price" column F = 0.
            'To avoid division by ZERO I made loop to search the next non-zero value in this ticker category (in case if Total Stock is NOT zero).
            'If TOtal Stock is zero - Percent Change will be 0 too.
            ' Looking for the next non-zero value in a row #3
            If (totalStock <> 0) And (ws.Cells(i - tick_num + 1, 3) = 0) Then
                
                For m = 1 To (tick_num - 1)
                    If ws.Cells(i - tick_num + 1 + m, 3).Value <> 0 Then
                        ws.Cells(i - tick_num + 1, 3) = ws.Cells(i - tick_num + 1 + m, 3)
                        Exit For
                    End If
                Next m
            End If
            
            ' Looking for the previous non-zero value in a row #6
            If (totalStock <> 0) And (ws.Cells(i, 6) = 0) Then
                For n = 1 To (tick_num - 1)
                    If ws.Cells(i - n, 6).Value <> 0 Then
                        ws.Cells(i, 6) = ws.Cells(i - n, 6)
                        Exit For
                    End If
                Next n
             End If
            
            If totalStock = 0 Then
                percent = 0 'to avoid division by ZERO (PLNT ticker has all "0" values.
            Else
                percent = (ws.Cells(i, 6).Value / ws.Cells(i - tick_num + 1, 3).Value) - 1
            End If
            
            ws.Cells(1 + count, 12).Value = Format(percent, "Percent")
        
        
            '---------------YEARLY CHANGES--------------------
            
            year = ws.Cells(i, 6).Value - ws.Cells(i - tick_num + 1, 3).Value
            ws.Cells(1 + count, 11).Value = year
            
            '---------------CONDITIONAL FORMATING--------------------
            'Conditional Formatting for Year Change: positive change in green and negative change in red.
            If year > 0 Then
                ws.Cells(1 + count, 11).Interior.ColorIndex = 4
            Else
                ws.Cells(1 + count, 11).Interior.ColorIndex = 3
            End If


            'Total Stock Volume set 0, when ticker type changed
            totalStock = 0
        
            'set is as zerro to start counting of amount of tickers in the next category
            tick_num = 0

        End If
    Next i
    
   '------------------------------
    'Part-II
    '------------------------------

    '---------------Looking for MINIMUM and MAXIMUM--------------------
    'Greatest % Increase / Greatest % Decrease / Greates Total Volume
    
    'Look to find Max/Min values
    Dim count_2 As Integer
    count_2 = 1  'it will be a line number were Max/Min value is founded. I will use it after to return the corresponded Ticker type.

    Dim find_ticker_max, find_ticker_min, find_ticker_volumeMax As Integer

    percentMax = 0
    percentMin = 0
    totalStockMax = 0

    For j = 2 To count  'count is number of Ticker types
        count_2 = count_2 + 1
        'Greatest % Increase
        If ws.Cells(j, 12).Value > percentMax Then
            percentMax = ws.Cells(j, 12).Value
            find_ticker_max = count_2 'need to find the ticker for this max value
        
        'Greatest % Decrease
        ElseIf ws.Cells(j, 12).Value < percentMin Then
            percentMin = ws.Cells(j, 12).Value
            find_ticker_min = count_2 'need to find the ticker for this min value
        End If
        'Greates Total Volume
        If ws.Cells(j, 13).Value > totalStockMax Then
            totalStockMax = ws.Cells(j, 13).Value
            find_ticker_volumeMax = count_2 'need to find the ticker for this max value
        End If
    Next j
    
    'Printing calculated data for: Greatest % Increase / Greatest % Decrease / Greates Total Volume
    
    ws.Cells(2, 18).Value = Format(percentMax, "Percent")
    ws.Cells(3, 18).Value = Format(percentMin, "Percent")
    'Cells(4, 18).Value = Format(totalStockMax, "Scientific")
    ws.Cells(4, 18).Value = totalStockMax
    ws.Cells(4, 18).NumberFormat = "0.0000E+00" 'to return the Scientific format with 4 decimol

    'Looking for Tickers corresponding to "Greatest % Increase / Greatest % Decrease / Greates Total Volume"
    ws.Cells(2, 17).Value = ws.Cells(find_ticker_max, 10).Value
    ws.Cells(3, 17).Value = ws.Cells(find_ticker_min, 10).Value
    ws.Cells(4, 17).Value = ws.Cells(find_ticker_volumeMax, 10).Value

    'Formating of cells
    'Range("S2:S4").HorizontalAlignment = xlLeft
    'Range("T2:T4").HorizontalAlignment = xlRight
    ws.Range("Q1:R1").HorizontalAlignment = xlCenter
    ws.Columns("K").HorizontalAlignment = xlCenter
    
    'The following code will fit the cell wigth to the text in it.
    ws.Columns("P").AutoFit
    ws.Columns("K:M").AutoFit
    
Next ws

End Sub
