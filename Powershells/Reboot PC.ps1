# Prompt for the computer name
$ComputerName = Read-Host "Name of PC to Reboot:"

# Reboot the specified computer
Restart-Computer -ComputerName $ComputerName -Force -Credentials CODEL\SBartle-admin