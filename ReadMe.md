Create self signed certificate:

PowerShell (Administrator):

1. New-SelfSignedCertificate -certstorelocation cert:\localmachine\my -dnsname localhost
2. Write down [Thumbprint]

CommandPrompt (Adminstrator):

3. netsh http add sslcert ipport=0.0.0.0:8082 appid={12345678-db90-4b66-8b01-88f7af2e36bf} certhash=[Thumbprint]

Windows Certificate Manager (Local Computer):

4. Find certificate under Personal
5. Copy certificate to Trusted Root Certification Authorities