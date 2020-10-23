const fs = require("fs");
const exec = require("./exec");
const writeChangelog = require("./changelog");
const { getVersion, setVersion } = require("./version");
const path = require("path");
const tmp = fs.mkdtempSync(`.release-tmp-`);

const newVersion = process.argv[2];
if (!newVersion) {
  throw new Error("usage: `release new_version [branch]`");
}

const branch = process.argv[3];

(async () => {
  if (!fs.existsSync(".release")) {
    fs.writeFileSync(".release", tmp);
  } else {
    console.error(
      "Found a pending release. Please run `npm run release:clean`"
    );
    process.exit(1);
  }

  const lastVersionFile = path.resolve(tmp, "current-version");
  const version = await getVersion();

  fs.writeFileSync(lastVersionFile, version);

  if (branch) {
    await exec(`git checkout ${branch}`);
  }

  await exec("git pull");
  await exec(`git checkout -b prepare/${newVersion}`);

  await setVersion(newVersion);

  await writeChangelog(newVersion);

  await exec("npm run release:clean");
})();
