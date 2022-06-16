function Get-HardwareType {
 
<#
 
.SYNOPSIS
Get-HardwareType is used to determine if a computer is a laptop of desktop.
 
.DESCRIPTION
Get-HardwareType is used to determine a computer's hardware type of whether or not the
computer is a laptop or a desktop.

0 (0x0) - Unspecified
1 (0x1) - Desktop
2 (0x2) - Laptop\Mobile
3 (0x3) - Workstation
4 (0x4) - Enterprise Server
5 (0x5) - Small Office and Home Office (SOHO) Server
6 (0x6) - Appliance PC
7 (0x7) - Performance Server
8 (0x8) - Maximum
 
#>
 
    $hardwaretype = Get-WmiObject -Class Win32_ComputerSystem -Property PCSystemType
        If ($hardwaretype -ne 2)
        {
        return $true
        }
        Else
        {
        return $false
        }}
 
If (Get-HardwareType)
    {
        <# "$Env:ComputerName is a Desktop" #>
        "Your computer is a Desktop"
    }
Else
    {
        "Your computer is a Laptop"
    }