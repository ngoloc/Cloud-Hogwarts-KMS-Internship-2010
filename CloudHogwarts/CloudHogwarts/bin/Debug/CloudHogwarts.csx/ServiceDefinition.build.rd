<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CloudHogwarts" generation="1" functional="0" release="0" Id="f24f7dc5-e108-48b6-bae7-20cb80385b8d" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="CloudHogwartsGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="CloudHogwarts_WebRole:HttpIn" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/CloudHogwarts/CloudHogwartsGroup/LB:CloudHogwarts_WebRole:HttpIn" />
          </inToChannel>
        </inPort>
        <inPort name="CloudHogwarts_WorkerRole:NotificationService" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/CloudHogwarts/CloudHogwartsGroup/LB:CloudHogwarts_WorkerRole:NotificationService" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="CloudHogwarts_WebRole:?IsSimulationEnvironment?" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRole:?IsSimulationEnvironment?" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WebRole:?RoleHostDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRole:?RoleHostDebugger?" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WebRole:?StartupTaskDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRole:?StartupTaskDebugger?" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WebRole:ContainerName" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRole:ContainerName" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WebRole:DataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRole:DataConnectionString" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WebRole:TableDataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRole:TableDataConnectionString" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WebRoleInstances" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WorkerRole:?IsSimulationEnvironment?" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WorkerRole:?IsSimulationEnvironment?" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WorkerRole:?RoleHostDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WorkerRole:?RoleHostDebugger?" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WorkerRole:?StartupTaskDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WorkerRole:?StartupTaskDebugger?" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WorkerRole:TableDataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WorkerRole:TableDataConnectionString" />
          </maps>
        </aCS>
        <aCS name="CloudHogwarts_WorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CloudHogwarts/CloudHogwartsGroup/MapCloudHogwarts_WorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:CloudHogwarts_WebRole:HttpIn">
          <toPorts>
            <inPortMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/HttpIn" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:CloudHogwarts_WorkerRole:NotificationService">
          <toPorts>
            <inPortMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRole/NotificationService" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapCloudHogwarts_WebRole:?IsSimulationEnvironment?" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/?IsSimulationEnvironment?" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WebRole:?RoleHostDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/?RoleHostDebugger?" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WebRole:?StartupTaskDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/?StartupTaskDebugger?" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WebRole:ContainerName" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/ContainerName" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WebRole:DataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/DataConnectionString" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WebRole:TableDataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole/TableDataConnectionString" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRoleInstances" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WorkerRole:?IsSimulationEnvironment?" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRole/?IsSimulationEnvironment?" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WorkerRole:?RoleHostDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRole/?RoleHostDebugger?" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WorkerRole:?StartupTaskDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRole/?StartupTaskDebugger?" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WorkerRole:TableDataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRole/TableDataConnectionString" />
          </setting>
        </map>
        <map name="MapCloudHogwarts_WorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="CloudHogwarts_WebRole" generation="1" functional="0" release="0" software="C:\Users\Loc Ngo\Documents\Visual Studio 2010\Projects\CloudHogwarts\CloudHogwarts\bin\Debug\CloudHogwarts.csx\roles\CloudHogwarts_WebRole" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="HttpIn" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="?IsSimulationEnvironment?" defaultValue="" />
              <aCS name="?RoleHostDebugger?" defaultValue="" />
              <aCS name="?StartupTaskDebugger?" defaultValue="" />
              <aCS name="ContainerName" defaultValue="" />
              <aCS name="DataConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="TableDataConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CloudHogwarts_WebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CloudHogwarts_WebRole&quot;&gt;&lt;e name=&quot;HttpIn&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;CloudHogwarts_WorkerRole&quot;&gt;&lt;e name=&quot;NotificationService&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRoleInstances" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="CloudHogwarts_WorkerRole" generation="1" functional="0" release="0" software="C:\Users\Loc Ngo\Documents\Visual Studio 2010\Projects\CloudHogwarts\CloudHogwarts\bin\Debug\CloudHogwarts.csx\roles\CloudHogwarts_WorkerRole" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="NotificationService" protocol="tcp" portRanges="3030" />
            </componentports>
            <settings>
              <aCS name="?IsSimulationEnvironment?" defaultValue="" />
              <aCS name="?RoleHostDebugger?" defaultValue="" />
              <aCS name="?StartupTaskDebugger?" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="TableDataConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CloudHogwarts_WorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CloudHogwarts_WebRole&quot;&gt;&lt;e name=&quot;HttpIn&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;CloudHogwarts_WorkerRole&quot;&gt;&lt;e name=&quot;NotificationService&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRoleInstances" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyID name="CloudHogwarts_WebRoleInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="CloudHogwarts_WorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="2db9ad1a-3aa1-473b-9a43-a3363b1ec725" ref="Microsoft.RedDog.Contract\ServiceContract\CloudHogwartsContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="f1d0f482-9265-4609-a50d-8ab2af52c0c7" ref="Microsoft.RedDog.Contract\Interface\CloudHogwarts_WebRole:HttpIn@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WebRole:HttpIn" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="131fd131-d873-447c-8b4d-7c52d4dabb6b" ref="Microsoft.RedDog.Contract\Interface\CloudHogwarts_WorkerRole:NotificationService@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/CloudHogwarts/CloudHogwartsGroup/CloudHogwarts_WorkerRole:NotificationService" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>