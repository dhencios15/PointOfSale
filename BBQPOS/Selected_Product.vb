﻿Public Class Selected_Product

    Dim strQuery = ""
    Dim strQueryQuantity = ""


    Private Sub Selected_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtName.Text = Product_Name
        txtPrice.Text = Product_Price
        txtTotal.Text = Product_Price
        txtQuantity.Text = 1

        If CInt(txtQuantity.Text) > Product_Quantity Then
            txtQuantity.Text = Product_Quantity
        End If

    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(13) Then ' When Enterkey Press

            Try
                If txtQuantity.Text = 0 Or txtQuantity.Text = "" Then
                    Product_Total = 0
                    Product_Name = ""
                    Product_Quantity = 0
                    Product_Price = 0
                    Me.Close()
                Else
                    Product_Name = txtName.Text
                    Product_Price = txtPrice.Text
                    Product_Quantity = txtQuantity.Text
                    Product_Total = txtTotal.Text
                    Me.Close()
                End If
            Catch ex As Exception
                Me.Close()
            End Try

            'If txtQuantity.Text = "" Then
            '    MsgBox("Please input the quantity of the desired item.")
            '    txtQuantity.Text = 1
            'ElseIf CInt(txtQuantity.Text) > Product_Quantity Then
            '    MsgBox("Order quantity must not exceed the item's stock quantity!")
            '    txtQuantity.Text = Product_Quantity

            'Else
            '    Product_Name = txtName.Text
            '    Product_Price = txtPrice.Text
            '    Product_Quantity = txtQuantity.Text
            '    Product_Total = txtTotal.Text
            '    Me.Close()
            'End If
            'If txtQuantity.Text = "" Then
            '    txtQuantity.Text = 1
            'End If



        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then ' When ESCKey press
            Product_Total = 0
            Product_Name = ""
            Product_Quantity = 0
            Product_Price = 0

            Me.Close()
        End If
    End Sub

    Private Sub TxtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged

        Try
            If CInt(txtQuantity.Text) > Product_Quantity Then
                MsgBox("Order quantity must not exceed the item's stock quantity!")
                txtQuantity.Text = Product_Quantity
            ElseIf txtQuantity.Text = "" Then
                MsgBox("Please input the quantity of the desired item.")
                txtQuantity.Text = 1
            Else
                txtTotal.Text = totalPrice(Product_Price, txtQuantity.Text, txtTotal.Text)
            End If

        Catch ex As Exception
            txtTotal.Text = Product_Price
        End Try

    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If txtQuantity.Text = 0 Or txtQuantity.Text = "" Then
                Product_Total = 0
                Product_Name = ""
                Product_Quantity = 0
                Product_Price = 0
                Me.Close()
            Else
                Product_Name = txtName.Text
                Product_Price = txtPrice.Text
                Product_Quantity = txtQuantity.Text
                Product_Total = txtTotal.Text
                Me.Close()
            End If
        Catch ex As Exception
            Me.Close()
        End Try

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Product_Total = 0
        Product_Name = ""
        Product_Quantity = 0
        Product_Price = 0
        Me.Close()
    End Sub
End Class