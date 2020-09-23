Sub ticker():

Dim rows As Long

Dim ticker As String

Dim count As Long

Dim tick_num As Long

Dim year As Double

Dim percent As Double

Dim totalStock As Double

Dim percentMax As Double

Dim percentMin As Double

Dim totalStockMax As Double

Dim ws As Worksheet

Dim m, n As Integer

'Loop througth All Sheets in the WorkBook

For Each ws In Worksheets

    'Activating the Sheet
    ws.Activate
    
    'to find the last populated cell in a particular column
    rows = ws.Cells(ws.Cells.rows.count, 1).End(xlUp).Row
    ws.Cells(1, 8).Value = rows
    
    ws.Cells(1, 10).Value = "Ticker"
    ws.Cells(1, 11).Value = "Yearly Change"
    ws.Cells(1, 12).Value = "Percent Change"
    ws.Cells(1, 13).Value = "Total Stock Volume"

    ws.Cells(2, 18).Value = "Greatest % Increase"
    ws.Cells(3, 18).Value = "Greatest % Decrease"
    ws.Cells(4, 18).Value = "Greates Total Volume"

    ws.Cells(1, 19).Value = "Ticker"
    ws.Cells(1, 20).Value = "Value"

    'Calculating data
    tick_num = 0
    count = 0
    For i = 2 To rows
        tick_num = tick_num + 1 'to count # of tickers per category
        
        If ws.Cells(i + 1, 1).Value <> ws.Cells(i, 1).Value Then
        
            count = count + 1 'count only ticker changes name
        
            'return the symbol of Ticker to the F column (gives us the column of all types of tickers)
            ws.Cells(1 + count, 10).Value = ws.Cells(i, 1).Value
        
            'numbers tickers in one category
            ws.Cells(1 + count, 15).Value = tick_num
        
            'Calculating year
            year = ws.Cells(i, 6).Value - ws.Cells(i - tick_num + 1, 3).Value
            ws.Cells(1 + count, 11).Value = year
        
            'Total Stock Volume - SUM function for the Range
            totalStock = Application.Sum(Range(ws.Cells(i - tick_num + 1, 7), ws.Cells(i, 7)))
            ws.Cells(1 + count, 13).Value = totalStock
        
            'Percent Change calculation

                        
            ' Looking for the next non-zero value in a row #3
            If (totalStock <> 0) And (ws.Cells(i - tick_num + 1, 3) = 0) Then
                For m = 1 To tick_num
                    If ws.Cells(m + 1, 3).Value <> 0 Then
                        ws.Cells(i - tick_num + 1, 3) = ws.Cells(m + 1, 3)
                        Exit For
                    End If
                Next m
            End If
            
            ' Looking for the previous non-zero value in a row #6
            If (totalStock <> 0) And (ws.Cells(i, 6) = 0) Then
                For n = 1 To tick_num
                    If ws.Cells(tick_num - n, 6).Value <> 0 Then
                        ws.Cells(i, 6) = ws.Cells(tick_num - n, 6)
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
        
        
            'Conditional Formatting for Year Change: positive change in green and negative change in red.
            If year > 0 Then
                ws.Cells(1 + count, 11).Interior.ColorIndex = 4
            Else
                ws.Cells(1 + count, 11).Interior.ColorIndex = 3
            End If
        
           
            'Total Stock Volume set 0, when ticker type changed
            totalStock = 0
        
        
            'set is as zerro to start counting of numbers of next ticker
            tick_num = 0

        End If
    Next i
    
    'Look to find Max/Min values

    Dim count_2 As Integer
    count_2 = 1  'it will be a Row's number were Max/Min value is founded. I will use it after to return the orresponded Ticker type.

    Dim find_ticker_max, find_ticker_min, find_ticker_volumeMax As Integer

    percentMax = 0
    percentMin = 0
    totalStockMax = 0

    For j = 2 To count  'count is number of Ticker types
        count_2 = count_2 + 1
    
        If ws.Cells(j, 12).Value > percentMax Then
            percentMax = ws.Cells(j, 12).Value
            find_ticker_max = count_2
        
        ElseIf ws.Cells(j, 12).Value < percentMin Then
            percentMin = ws.Cells(j, 12).Value
            find_ticker_min = count_2
        End If
    
        If ws.Cells(j, 13).Value > totalStockMax Then
            totalStockMax = ws.Cells(j, 13).Value
            find_ticker_volumeMax = count_2
        End If
    Next j
    
    'Printing calculated Data
    
    ws.Cells(2, 20).Value = Format(percentMax, "Percent")
    ws.Cells(3, 20).Value = Format(percentMin, "Percent")
    ws.Cells(4, 20).Value = Format(totalStockMax, "0.0000E+00")

    ws.Cells(2, 19).Value = ws.Cells(find_ticker_max, 10).Value
    ws.Cells(3, 19).Value = ws.Cells(find_ticker_min, 10).Value
    ws.Cells(4, 19).Value = ws.Cells(find_ticker_volumeMax, 10).Value
    
    'ws.Activate
Next ws

End Sub



