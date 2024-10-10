[void][Reflection.Assembly]::LoadWithPartialName('Microsoft.VisualBasic')

$title = 'PC Name'
$msg = 'Enter the hostname:'

$pcname = [Microsoft.VisualBasic.Interaction]::InputBox($msg, $title)

Get-WmiObject Win32_Product -ComputerName $pcname  | Select-Object -Property IdentifyingNumber, Name

$ComputerName = 'Computer'
$number = '{96332EE8-8C21-4A28-8BF3-F68DAF073906}' #Gateway2 ProductID
$gw2 = Get-WmiObject Win32_Product -ComputerName $pcname | Where-Object {$_.IdentifyingNumber -eq $number}
if ($gw2) {
  $gw2.Uninstall()
}
else {
  $number + ' is not installed on ' + $pcname
}

$session = New-PSSession -ComputerName $pcname
Copy-Item -Path '\\cod-vps-fs01\Development\Software Installation\Gateway 2\Gateway2.exe' -ToSession $session -Destination 'c:\windows\temp\Gateway2.exe' -Force
Invoke-Command -Session $session -ScriptBlock   {
   Start-Process 'c:\windows\temp\Gateway2.exe' -ArgumentList '--quiet' -Wait
   Move-Item -Path 'c:\windows\temp\Gateway2.exe'    
} 