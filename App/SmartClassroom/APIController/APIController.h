// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the APICONTROLLER_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// APICONTROLLER_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef APICONTROLLER_EXPORTS
#define APICONTROLLER_API __declspec(dllexport)
#else
#define APICONTROLLER_API __declspec(dllimport)
#endif

#include "ModuleFactory.h"

// This class is exported from the APIController.dll
class APICONTROLLER_API CAPIController {
public:
	static CAPIController* GetInstance();

	// Teacher Part
	HRESULT BuildTeacherGraph(BOOL bDisplay, HWND displayWnd, HWND notifyWnd);

	HRESULT AddCamera(int cameraId, int comNum, int baudRate);
	HRESULT TeacherPTZUp();
	HRESULT TeacherPTZDown();
	HRESULT TeacherPTZLeft();
	HRESULT TeacherPTZRight();
	HRESULT TeacherPTZZoomIn();
	HRESULT TeacherPTZZoomOut();
	HRESULT TeacherPTZStop();

	HRESULT TeacherPTZSetPrePos(int locId, int pixLeft, int pixRight, double realLeft, double realRight);
	HRESULT TeacherPTZRecallPrePos(int locId);

	HRESULT TeacherGraphRun();
	HRESULT TeacherGraphStop();

	HRESULT TeacherTrackingStart();
	HRESULT TeacherTrackingStop();

	HRESULT TeacherSetEnvParams(double roomWidth, double cameraDistance);
	HRESULT TeacherGetEnvParams(double& roomWidth, double& cameraDistance);

	// Student Part
	HRESULT BuildStudentGraph();

	// LaserPoint Part
	HRESULT BuildLaserPointGraph();

private:
	CAPIController(void);
	~CAPIController();

	static CAPIController* m_pInstance;
	CModuleFactory* m_pModuleFactory;
	// TODO: add your methods here.
};

