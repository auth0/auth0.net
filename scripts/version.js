const fs = require("fs").promises;
const xml2js = require("xml2js");

async function loadXMLDoc(filePath) {
  const fileData = await fs.readFile(filePath, "utf-8");
  const parser = new xml2js.Parser();
  return parser.parseStringPromise(fileData.substring(0, fileData.length));
}

async function saveXMLDoc(filePath, content) {
  const builder = new xml2js.Builder({ headless: true });
  const xml = builder.buildObject(content);

  return fs.writeFile(filePath, xml, "utf-8");
}

let commonPropsJson = null;
async function loadCommonProps() {
  const XMLPath = "./build/common.props";
  commonPropsJson = commonPropsJson || (await loadXMLDoc(XMLPath));
  return commonPropsJson;
}

async function saveCommonProps(content) {
  const XMLPath = "./build/common.props";
  return saveXMLDoc(XMLPath, content);
}

module.exports = {
  getVersion: async () => {
    const commonProps = await loadCommonProps();
    const {
      Major,
      Minor,
      Revision,
    } = commonProps.Project.PropertyGroup.find((propertyGroup) =>
      Object.keys(propertyGroup).includes("Major")
    );
    return `${Major}.${Minor}.${Revision}`;
  },
  setVersion: async (version) => {
    const commonProps = await loadCommonProps();
    const propertyGroupWithVersion = commonProps.Project.PropertyGroup.find(
      (propertyGroup) => Object.keys(propertyGroup).includes("Major")
    );
    const [major, minor, revision] = version.split(".");

    propertyGroupWithVersion.Major = major;
    propertyGroupWithVersion.Minor = minor;
    propertyGroupWithVersion.Revision = revision;

    saveCommonProps(commonProps);
  },
};
