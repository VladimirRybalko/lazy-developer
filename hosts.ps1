$path = "C:\Windows\System32\drivers\etc\";
$myhostpath = ($path + "my-hosts\");

function switch-host {
	param ([string]$env)
	
	$e = $env.ToLowerInvariant();		
	Copy-Item ($myhostpath + $e) ($path + 'hosts') -Force
	ipconfig /flushdns >$null

	Write-Output ('Success switching to ' + $env + '.')

}; Set-Alias sh switch-host

function create {
	param ([string]$env)

	New-Item ($myhostpath + $env.ToLowerInvariant()) -ItemType File > $null

	Write-Output ('Success creating ' + $env + ' host.')
}

function open {
	param ([string]$env)

	Start-Process notepad++ ($myhostpath + $env.ToLowerInvariant())
}