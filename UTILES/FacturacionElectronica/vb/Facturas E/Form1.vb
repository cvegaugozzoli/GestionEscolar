Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim wsfex As FEAFIPLib.BIWSFEXV1
        wsfex = New FEAFIPLib.BIWSFEXV1
        If wsfex.login("..\..\..\certificado.pfx", "feafip") Then

            Dim Id, nro, ptoVta, tipoComp As Long

            ptoVta = 10
            tipoComp = 19 ' Facturas E

            If Not wsfex.recuperaLastID(Id) Then
                MessageBox.Show(wsfex.ErrorDesc)
            End If
            Id = Id + 1

            If Not wsfex.recuperaLastCMP(ptoVta, tipoComp, nro) Then
                MessageBox.Show(wsfex.ErrorDesc)
            End If
            nro = nro + 1

            wsfex.agregaFactura(Id, Date.Now, tipoComp, ptoVta, nro, 2, "", 201, "chile sa", 50000000032, "texto", "", "DOL", 8.8, "", 100, "", "", "FOB", "FOB", 1)
            wsfex.agregaItem("11111", "remera ", 1, 1, 100, 100, 0)
            If wsfex.autorizar Then

                Dim CAE As String = ""
                Dim Resultado As String = ""
                Dim Reproceso As String = ""
                Dim Vencimiento As DateTime
                wsfex.autorizarRespuesta(CAE, Vencimiento, Resultado, Reproceso)
                MessageBox.Show("Felicitaciones! Si ve este mensaje instalo correctamente FEAFIP. CAE y Vencimiento: " + CAE + " " + Vencimiento.ToString())

            Else
                MessageBox.Show(wsfex.ErrorDesc)

            End If
        Else
            MessageBox.Show(wsfex.ErrorDesc)
        End If

    End Sub
End Class
