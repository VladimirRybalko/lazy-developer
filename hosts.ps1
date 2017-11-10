$path = "C:\Windows\System32\drivers\etc\";
$myhostpath = ($path + "my-hosts\");

function Switch-Host {
	param ([string]$env)
	
	$e = $env.ToLowerInvariant();		
	Copy-Item ($myhostpath + $e) ($path + 'hosts') -Force
	ipconfig /flushdns >$null

	Write-Output ('Success switching to ' + $env + '.')

}; Set-Alias sh Switch-Host

function Create-Host {
	param ([string]$env)

	New-Item ($myhostpath + $env.ToLowerInvariant()) -ItemType File > $null

	Write-Output ('Success creating ' + $env + ' host.')
}; Set-Alias ch Create-Host

function Open-Host {
	param ([string]$env)

	Start-Process notepad++ ($myhostpath + $env.ToLowerInvariant())
}; Set-Alias oph Open-Host


function Open-Current-Host {

	Start-Process notepad++ ($path + 'hosts')
}; Set-Alias opch Open-Current-Host